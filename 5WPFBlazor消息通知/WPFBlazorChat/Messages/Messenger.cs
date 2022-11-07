using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WPFBlazorChat.Messages;

public class Messenger : IMessenger
{
    public static readonly Messenger Default = new();
    private readonly object registerLock = new();

    private Dictionary<Type, List<WeakActionAndToken>>? recipientsOfSubclassesAction;

    public void Subscribe<TMessage>(object recipient, Action<TMessage> action, ThreadOption threadOption)
        where TMessage : Message
    {
        lock (registerLock)
        {
            var messageType = typeof(TMessage);

            recipientsOfSubclassesAction ??= new Dictionary<Type, List<WeakActionAndToken>>();

            List<WeakActionAndToken> list;

            if (!recipientsOfSubclassesAction.ContainsKey(messageType))
            {
                list = new List<WeakActionAndToken>();
                recipientsOfSubclassesAction.Add(messageType, list);
            }
            else
            {
                list = recipientsOfSubclassesAction[messageType];
            }

            var item = new WeakActionAndToken
                { Recipient = recipient, ThreadOption = threadOption, Action = action };

            list.Add(item);
        }
    }

    public void Unsubscribe<TMessage>(object? recipient, Action<TMessage>? action) where TMessage : Message
    {
        var messageType = typeof(TMessage);

        if (recipient == null || recipientsOfSubclassesAction == null ||
            recipientsOfSubclassesAction.Count == 0 || !recipientsOfSubclassesAction.ContainsKey(messageType))
            return;

        var lstActions = recipientsOfSubclassesAction[messageType];
        for (var i = lstActions.Count - 1; i >= 0; i--)
        {
            var item = lstActions[i];
            var pastAction = item.Action;

            if (pastAction != null
                && recipient == pastAction.Target
                && (action == null || action.Method.Name == pastAction.Method.Name))
                lstActions.Remove(item);
        }
    }

    public void Publish<TMessage>(object sender, TMessage message) where TMessage : Message
    {
        var messageType = typeof(TMessage);

        if (recipientsOfSubclassesAction != null)
        {
            var listClone = recipientsOfSubclassesAction.Keys.Take(recipientsOfSubclassesAction.Count)
                .ToList();

            foreach (var type in listClone)
            {
                List<WeakActionAndToken>? list = null;

                if (messageType == type || messageType.IsSubclassOf(type) || type.IsAssignableFrom(messageType))
                    list = recipientsOfSubclassesAction[type]
                        .Take(recipientsOfSubclassesAction[type].Count)
                        .ToList();

                if (list is { Count: > 0 }) SendToList(message, list);
            }
        }
    }

    private void SendToList<TMessage>(TMessage message, IEnumerable<WeakActionAndToken> weakActionsAndTokens)
        where TMessage : Message
    {
        var list = weakActionsAndTokens.ToList();
        var listClone = list.Take(list.Count()).ToList();

        foreach (var item in listClone)
            if (item.Action is { Target: { } })
                switch (item.ThreadOption)
                {
                    case ThreadOption.BackgroundThread:
                        Task.Run(() => { item.ExecuteWithObject(message); });
                        break;
                    case ThreadOption.UiThread:
                        SynchronizationContext.Current!.Post(_ => { item.ExecuteWithObject(message); }, null);
                        break;
                    default:
                        item.ExecuteWithObject(message);
                        break;
                }
    }
}

public class WeakActionAndToken
{
    public object? Recipient { get; set; }

    public ThreadOption ThreadOption { get; set; }

    public Delegate? Action { get; set; }

    public string? Tag { get; set; }

    public void ExecuteWithObject<TMessage>(TMessage message) where TMessage : Message
    {
        if (Action is Action<TMessage> factAction) factAction.Invoke(message);
    }
}
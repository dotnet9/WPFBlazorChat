using System;

namespace WPFBlazorChat.Messages;

public interface IMessenger
{
    void Subscribe<TMessage>(object recipient, Action<TMessage> action,
        ThreadOption threadOption = ThreadOption.PublisherThread) where TMessage : Message;

    void Unsubscribe<TMessage>(object recipient, Action<TMessage>? action = null) where TMessage : Message;

    void Publish<TMessage>(object sender, TMessage message) where TMessage : Message;
}

public enum ThreadOption
{
    PublisherThread,
    BackgroundThread,
    UiThread
}
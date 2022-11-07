using System;

namespace WPFBlazorChat.Messages;

public abstract class Message
{
    protected Message(object sender)
    {
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
    }

    public object Sender { get; }
}
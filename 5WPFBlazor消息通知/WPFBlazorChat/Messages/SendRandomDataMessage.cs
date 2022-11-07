namespace WPFBlazorChat.Messages;

public class SendRandomDataMessage : Message
{
    public SendRandomDataMessage(object sender, int number) : base(sender)
    {
        Number = number;
    }

    public int Number { get; set; }
}
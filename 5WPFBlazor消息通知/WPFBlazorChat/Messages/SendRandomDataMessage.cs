namespace WPFBlazorChat.Messages;

public class SendRandomDataMessage : Message
{
    public int Number { get; set; }

    public SendRandomDataMessage(object sender, int number) : base(sender)
    {
        this.Number = number;
    }
}
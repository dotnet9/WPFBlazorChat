namespace WPFBlazorChat.Shared.Models;

public record ChatLog(User Sender, User Recipient, string Message, DateTime SendTime);
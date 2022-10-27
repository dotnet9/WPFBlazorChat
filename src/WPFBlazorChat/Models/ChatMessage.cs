namespace WPFBlazorChat.Models;

public record ChatMessage(string Sender, string? Recipient, string Message, DateTime SendTime);
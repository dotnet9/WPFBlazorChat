namespace WPFBlazorChat.Shared.Models;

public record ChatLog(string Sender, string? Recipient, string Message, DateTime SendTime);
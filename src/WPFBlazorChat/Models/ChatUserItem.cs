namespace WPFBlazorChat.Models;
public class ChatUserItem
{
    public string? Header { get; set; }
    public string? Avatar { get; set; }
    public string? UserName { get; set; }
    public string? Memo { get; set; }
    public bool Divider { get; set; }
    public bool Inset { get; set; }
}
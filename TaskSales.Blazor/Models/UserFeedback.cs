namespace TaskSales.Blazor.Models;

public class UserFeedback
{
    public string UserName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}


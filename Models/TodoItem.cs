namespace TodoApi.Models;  // Add this namespace declaration

public class TodoItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
} 
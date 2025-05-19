using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain;

public class Node
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column(TypeName = "timestamp with time zone")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
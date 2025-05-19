using System.ComponentModel.DataAnnotations;

namespace NoteApp.Dto;

public class NodeToCreateDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Заголовок обязательный")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Содержание обязательно")]
    public string Content { get; set; }
}
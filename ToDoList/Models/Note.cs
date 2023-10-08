using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Client { get; set; }
    }
}

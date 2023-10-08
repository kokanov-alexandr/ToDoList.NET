using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Введите клиента")]
        public string Client { get; set; }
    }

}


using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Note
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Client { get; set; }
    }
}

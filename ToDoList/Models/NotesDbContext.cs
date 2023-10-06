using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }

        public DbSet<Note> Notes => Set<Note>();
    }
}

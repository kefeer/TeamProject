using System.Data.Entity;
using Controller.Models;

namespace Controller
{
    class Context : DbContext
    {
        public Context() : base("LibraryDatabase")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Librarian> Librarians { get; set; }

        public void Seed()
        {
            Books.Add(new Book
            {
                Name = "Cat's cradle",
                Author = "Kurt Wonnengut",
                Genre = "Science fiction",
                IsOutdated = false,
                IsOwned = false,
                Year = "1963"
            });
            SaveChanges();
        }
    }
}

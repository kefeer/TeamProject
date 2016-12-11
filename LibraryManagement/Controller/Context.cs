using System.Data.Entity;
using System.Globalization;
using System.IO;
using Controller.Models;

namespace Controller
{
    public class Context : DbContext
    {
        public Context() : base("LibraryDatabase")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Librarian> Librarians { get; set; }

    }

    public class MyInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            using (FileStream fs = new FileStream(@"..\..\..\Books.csv", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string str;
                    string[] temp;
                    sr.ReadLine();

                    while ((str = sr.ReadLine()) != null)
                    {
                        temp = str.Split(';');

                        var book = new Book
                        {
                            Name = temp[0],
                            Author = temp[1],
                            Genre = temp[2],
                            Year = temp[3],
                            Department = temp[4]
                        };

                        context.Books.Add(book);
                        context.SaveChanges();
                    }

                }
            }
            base.Seed(context);
        }
    }
}

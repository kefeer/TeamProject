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
        public DbSet<BookReader> BooksReaders { get; set; }

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
                            Department = temp[4],
                            NumberInStock = int.Parse(temp[5])
                            
                        };

                        context.Books.Add(book);
                        context.SaveChanges();
                    }

                }
            }

            using (FileStream fs = new FileStream(@"..\..\..\Readers.csv", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string str;
                    string[] temp;
                    sr.ReadLine();

                    while ((str = sr.ReadLine()) != null)
                    {
                        temp = str.Split(';');

                        var reader = new Reader
                        {
                            Name = temp[0],
                            Surname = temp[1],
                            DateOfBirth = temp[2].ToString(),
                            TelephoneNumber = temp[3].ToString(),
                            Email = temp[4],
                            Username = temp[5],
                            Password = temp[6]

                        };

                        context.Readers.Add(reader);
                        context.SaveChanges();
                    }

                }
            }


            base.Seed(context);
        }
    }
}

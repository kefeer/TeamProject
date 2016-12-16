using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class AddBookToReaderForm : Form
    {
        public Reader Reader;

        public AddBookToReaderForm(Reader reader)
        {
            InitializeComponent();
            Reader = reader;
        }

        private void AddBookToReaderForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("7 days");
            comboBox1.Items.Add("14 days");
            comboBox1.Items.Add("21 days");
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var book = Initializer.db.Books.SingleOrDefault(c => c.Name == textBox1.Text);
            if (book != null)
            {
                TimeSpan timeSpan = new TimeSpan();

                book.NumberInStock--;
                Initializer.db.Entry(book).State = EntityState.Modified;
                if (book.NumberInStock < 1)
                {
                    MessageBox.Show("There are no such books available!");
                    return;
                }
               
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        timeSpan = new TimeSpan(7, 0, 0, 0);
                        break;
                    case 1:
                        timeSpan = new TimeSpan(14, 0, 0, 0);
                        break;
                    case 2:
                        timeSpan = new TimeSpan(21, 0, 0, 0);
                        break;
                }
                var bookreader = new BookReader
                {
                    BookID = book.ID,
                    ReaderID = Reader.ID,
                    DateTaken = DateTime.Now,
                    DateMustBeReturned = DateTime.Now + timeSpan
                };

                Initializer.db.BooksReaders.Add(bookreader);

                Initializer.db.SaveChanges();
                MessageBox.Show("Book has successfully been added to reader!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("There's no such book in the database!");
                this.Dispose();
            }
        }


    }
}

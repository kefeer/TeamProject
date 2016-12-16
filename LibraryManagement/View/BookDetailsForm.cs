using System;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class BookDetailsForm : Form
    {
        private Book book;
        public BookDetailsForm(Book book)
        {
            InitializeComponent();
            this.book = book;
        }

        private void BookDetailsForm_Load(object sender, EventArgs e)
        {
            bookName.Text = book.Name;
            bookAuthor.Text = book.Author;
            bookGenre.Text = book.Genre;
            bookYear.Text = book.Year;
            bookDepartment.Text = book.Department;
            bookNumberInStock.Text = book.NumberInStock.ToString();

            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (var bookReader in Initializer.db.BooksReaders)
            {
                if (bookReader.BookID == book.ID)
                {
                    var reader = Initializer.db.Readers.SingleOrDefault(c =>
                            c.ID == bookReader.ReaderID);

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader.Name + " " 
                        + reader.Surname;
                    i++;
                }
            }
        }
    }
}

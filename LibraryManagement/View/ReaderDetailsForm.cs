using System;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Controller;
using Controller.Models;

namespace View
{
    public partial class ReaderDetailsForm : Form
    {
        private Reader Reader;
        public ReaderDetailsForm(Reader reader)
        {
            InitializeComponent();
            Reader = reader;
        }
        private void ReaderDetailsForm_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Reader.Name;
            surnameLabel.Text = Reader.Surname;
            birthLabel.Text = Reader.DateOfBirth;
            telephoneLabel.Text = Reader.TelephoneNumber;
            emailLabel.Text = Reader.Email;
            usernameLabel.Text = Reader.Username;

            if (Reader.BooksOwned != null)
            {
               ShowBooks();
            }
        }
        private void deleteReaderButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete " +
                                               "this reader?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Initializer.db.Readers.Remove(Reader);
            Initializer.db.SaveChanges();

        }

        private void ShowBooks()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (var book in Reader.BooksOwned)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = book.Name;
                i++;
            }
        }

        private void addBookToReaderButton_Click(object sender, EventArgs e)
        {
            AddBookToReaderForm form = new AddBookToReaderForm(Reader);
            form.ShowDialog();
            this.Close();
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            string name = null;
            try
            {
                name = dataGridView1.SelectedCells[0].Value.ToString();

            }
            catch (Exception)
            {
                return;
            }

            
            Reader.BooksOwned.Remove(
                Initializer.db.Books.SingleOrDefault(c => c.Name == name));
            Initializer.db.Books.SingleOrDefault(c => c.Name == name).IsOwned = false;
            Initializer.db.Books.SingleOrDefault(c => c.Name == name).IsOutdated = false;
            Initializer.db.SaveChanges();

            MessageBox.Show("The book has successfully been removed!");

            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (var book in Reader.BooksOwned)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = book.Name;
            }
        }
    }
}

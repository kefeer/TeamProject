using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class LibrarianView : Form
    {
        private MainForm mainForm;

        public LibrarianView(MainForm mainform)
        {
            InitializeComponent();
            mainForm = mainform;
        }

        private void LibrarianView_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            int i = 0;
            foreach (var reader in Initializer.db.Readers)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = reader.Name;
                dataGridView1.Rows[i].Cells[1].Value = reader.Surname;
                dataGridView1.Rows[i].Cells[2].Value = reader.Username;
                i++;
            }
            i = 0;
            foreach (var book in Initializer.db.Books)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = book.Name;
                dataGridView2.Rows[i].Cells[1].Value = book.Author;
                dataGridView2.Rows[i].Cells[2].Value = book.Genre;
                dataGridView2.Rows[i].Cells[3].Value = book.Department;
                if (book.IsOwned)
                {
                    dataGridView2.Rows[i].Cells[4].Value = "Yes";
                    dataGridView2.Rows[i].Cells[6].Value = book.Reader.Name + " " +
                                                           book.Reader.Surname;

                }
                else
                    dataGridView2.Rows[i].Cells[4].Value = "No";
                if (book.IsOutdated)
                    dataGridView2.Rows[i].Cells[5].Value = "Yes";
                else
                    dataGridView2.Rows[i].Cells[5].Value = "No";
                i++;
            }
        }

        private void LibrarianView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Dispose();
        }

        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                var reader = Initializer.db.Readers.SingleOrDefault(
                    c => c.Username == username);

                ReaderDetailsForm detailsForm = new ReaderDetailsForm(reader);
                detailsForm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Please, select reader's row!");
            }
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            AddBookForm form = new AddBookForm();
            form.ShowDialog();
            FillData();
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete " +
                                              "this book?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string name = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    var book = Initializer.db.Books.SingleOrDefault(
                        c => c.Name == name);
                    Initializer.db.Books.Remove(book);
                    Initializer.db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Please, select a row with book!");
                    return;
                }


                FillData();
            }
        }
    }
}

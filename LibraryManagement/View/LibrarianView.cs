using System;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class LibrarianView : Form
    {
        private MainForm mainForm;
        private Librarian librarian;

        public LibrarianView(MainForm mainform, Librarian librarian)
        {
            InitializeComponent();
            mainForm = mainform;
            this.librarian = librarian;

        }

        private void LibrarianView_Load(object sender, EventArgs e)
        {
            FillData();
            label5.Text = librarian.Name + " " + librarian.Surname;
            label6.Text = librarian.Username;
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
                dataGridView2.Rows[i].Cells[4].Value = book.NumberInStock;
                foreach (var temp in Initializer.db.BooksReaders)
                {
                    if (book.ID == temp.BookID)
                    {
                        var reader = Initializer.db.Readers.SingleOrDefault(c =>
                            c.ID == temp.ReaderID);
                        dataGridView2.Rows[i].Cells[6].Value = reader.Name +
                                                               " " + reader.Surname;

                    }
                }
                if (book.IsOutdated)
                    dataGridView2.Rows[i].Cells[5].Value = "Yes";
                else
                    dataGridView2.Rows[i].Cells[5].Value = "No";
                i++;
            }
        }

        private void LibrarianView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.ShowBooks();
            mainForm.Visible = true;
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
            FillData();
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
                    foreach (var bookReader in Initializer.db.BooksReaders)
                    {
                        if (book.ID == bookReader.BookID)
                            Initializer.db.BooksReaders.Remove(bookReader);
                    }
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

        private void findReaderButton_Click(object sender, EventArgs e)
        {
            if (nameReaderRadio.Checked)
            {
                dataGridView1.Rows.Clear();
                int i = 0;
                foreach (var reader in Initializer.db.Readers)
                {
                    if (reader.Name.ToLower().Contains(textBox2.Text.ToLower()))
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = reader.Name;
                        dataGridView1.Rows[i].Cells[1].Value = reader.Surname;
                        dataGridView1.Rows[i].Cells[2].Value = reader.Username;
                        i++;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                int i = 0;
                foreach (var reader in Initializer.db.Readers)
                {
                    if (reader.Surname.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = reader.Name;
                        dataGridView1.Rows[i].Cells[1].Value = reader.Surname;
                        dataGridView1.Rows[i].Cells[2].Value = reader.Username;
                        i++;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                dataGridView1.Rows.Clear();

                int i = 0;
                foreach (var reader in Initializer.db.Readers)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader.Name;
                    dataGridView1.Rows[i].Cells[1].Value = reader.Surname;
                    dataGridView1.Rows[i].Cells[2].Value = reader.Username;
                    i++;
                }
            }
        }

        private void findBookButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            if (radioButton1.Checked)
            {
                dataGridView2.Rows.Clear();
                int i = 0;
                foreach (var book in Initializer.db.Books)
                {
                    if (book.Name.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = book.Name;
                        dataGridView2.Rows[i].Cells[1].Value = book.Author;
                        dataGridView2.Rows[i].Cells[2].Value = book.Genre;
                        dataGridView2.Rows[i].Cells[3].Value = book.Department;
                        dataGridView2.Rows[i].Cells[4].Value = book.NumberInStock;
                        foreach (var temp in Initializer.db.BooksReaders)
                        {
                            if (book.ID == temp.BookID)
                            {
                                var reader = Initializer.db.Readers.SingleOrDefault(c =>
                                    c.ID == temp.ReaderID);
                                dataGridView2.Rows[i].Cells[6].Value = reader.Name +
                                                                       " " + reader.Surname;

                            }
                        }
                        if (book.IsOutdated)
                            dataGridView2.Rows[i].Cells[5].Value = "Yes";
                        else
                            dataGridView2.Rows[i].Cells[5].Value = "No";
                        i++;

                    }
                }
            }
            if (radioButton2.Checked)
            {
                dataGridView2.Rows.Clear();

                int i = 0;
                foreach (var book in Initializer.db.Books)
                {
                    if (book.Author.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = book.Name;
                        dataGridView2.Rows[i].Cells[1].Value = book.Author;
                        dataGridView2.Rows[i].Cells[2].Value = book.Genre;
                        dataGridView2.Rows[i].Cells[3].Value = book.Department;
                        dataGridView2.Rows[i].Cells[4].Value = book.NumberInStock;
                        foreach (var temp in Initializer.db.BooksReaders)
                        {
                            if (book.ID == temp.BookID)
                            {
                                var reader = Initializer.db.Readers.SingleOrDefault(c =>
                                    c.ID == temp.ReaderID);
                                dataGridView2.Rows[i].Cells[6].Value = reader.Name +
                                                                       " " + reader.Surname;

                            }
                        }
                        if (book.IsOutdated)
                            dataGridView2.Rows[i].Cells[5].Value = "Yes";
                        else
                            dataGridView2.Rows[i].Cells[5].Value = "No";
                        i++;
                    }
                }
            }
            if (radioButton3.Checked)
            {
                dataGridView1.Rows.Clear();

                int i = 0;
                foreach (var book in Initializer.db.Books)
                {
                    if (book.Genre.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = book.Name;
                        dataGridView2.Rows[i].Cells[1].Value = book.Author;
                        dataGridView2.Rows[i].Cells[2].Value = book.Genre;
                        dataGridView2.Rows[i].Cells[3].Value = book.Department;
                        dataGridView2.Rows[i].Cells[4].Value = book.NumberInStock;
                        foreach (var temp in Initializer.db.BooksReaders)
                        {
                            if (book.ID == temp.BookID)
                            {
                                var reader = Initializer.db.Readers.SingleOrDefault(c =>
                                    c.ID == temp.ReaderID);
                                dataGridView2.Rows[i].Cells[6].Value = reader.Name +
                                                                       " " + reader.Surname;

                            }
                        }
                        if (book.IsOutdated)
                            dataGridView2.Rows[i].Cells[5].Value = "Yes";
                        else
                            dataGridView2.Rows[i].Cells[5].Value = "No";
                        i++;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataGridView2.Rows.Clear();
                int i = 0;
                foreach (var book in Initializer.db.Books)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = book.Name;
                    dataGridView2.Rows[i].Cells[1].Value = book.Author;
                    dataGridView2.Rows[i].Cells[2].Value = book.Genre;
                    dataGridView2.Rows[i].Cells[3].Value = book.Department;
                    dataGridView2.Rows[i].Cells[4].Value = book.NumberInStock;
                    foreach (var temp in Initializer.db.BooksReaders)
                    {
                        if (book.ID == temp.BookID)
                        {
                            var reader = Initializer.db.Readers.SingleOrDefault(c =>
                                c.ID == temp.ReaderID);
                            dataGridView2.Rows[i].Cells[6].Value = reader.Name +
                                                                   " " + reader.Surname;

                        }
                    }
                    if (book.IsOutdated)
                        dataGridView2.Rows[i].Cells[5].Value = "Yes";
                    else
                        dataGridView2.Rows[i].Cells[5].Value = "No";
                    i++;
                }
            }

        }

        private void linkAccountDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete " +
                                              "your account?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Initializer.db.Librarians.Remove(librarian);
                Initializer.db.SaveChanges();

                MessageBox.Show("Your account has successfully been removed!");
                this.Close();
                mainForm.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            try
            {
                name = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Please, choose book's row!");
                return;
            }

            var book = Initializer.db.Books.SingleOrDefault(
                c => c.Name == name);
            BookDetailsForm form = new BookDetailsForm(book);
            form.ShowDialog();
        }

        private void LibrarianView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Focused)
                if (e.KeyChar == (char)Keys.Enter)
                findReaderButton_Click(sender, e);
            if (textBox1.Focused)
                if (e.KeyChar == (char)Keys.Enter)
                    findBookButton_Click(sender, e);
        }

    }
}

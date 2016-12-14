using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class ReaderView : Form
    {
        private Reader reader;
        private MainForm mainForm;
        public ReaderView(MainForm mainForm, Reader reader)
        {
            InitializeComponent();
            this.reader = reader;
            this.mainForm = mainForm;
            label6.Text = reader.Name + reader.Surname;
            label7.Text = reader.Username;
        }

        private void ReaderView_Load(object sender, EventArgs e)
        {
            int i = 0;

            foreach (var temp in Initializer.db.BooksReaders)
            {
                if (temp.ReaderID == reader.ID)
                {
                    var book = Initializer.db.Books.SingleOrDefault(c =>
                        c.ID == temp.BookID);
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = book.Name;
                    dataGridView1.Rows[i].Cells[1].Value = book.Author;
                    dataGridView1.Rows[i].Cells[2].Value = book.Genre;
                    dataGridView1.Rows[i].Cells[3].Value =
                        (temp.DateMustBeReturned.Value - DateTime.Now).TotalDays.ToString("F0");
                    i++;


                    if ((temp.DateMustBeReturned.Value - DateTime.Now).TotalDays < 2)
                    {
                        listBox1.Items.Add(book.Name);
                    }

                    
                    if (book.IsOutdated)
                    {
                        listBox2.Items.Add(book.Name);
                    }

                }
            }
        }

        private void ReaderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.ShowBooks();
            mainForm.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
            mainForm.ShowBooks();
            mainForm.Visible = true;
        }
    }
}

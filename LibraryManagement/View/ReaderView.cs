using System;
using System.Globalization;
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
        }

        private void ReaderView_Load(object sender, EventArgs e)
        {
            int i = 0;

            foreach (var book in reader.BooksOwned)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = book.Name;
                dataGridView1.Rows[i].Cells[1].Value = book.Author;
                dataGridView1.Rows[i].Cells[2].Value = book.Genre;
                i++;

                if ((book.dateMustBeReturned.Value -
                    DateTime.Now).TotalDays <= 2 )
                {
                    listBox1.Items.Add(book.Name);
                }
                if (book.IsOutdated)
                {
                    listBox2.Items.Add(book.Name);
                }

            }
        }

        private void ReaderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.ShowBooks();
            mainForm.Visible = true;
        }
    }
}

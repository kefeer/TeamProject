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
            int j = 0;
            int k = 0;

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
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[j].Cells[0].Value = book.Name;
                    j++;
                }
                if (book.IsOutdated)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[k].Cells[0].Value = book.Name;
                    k++;
                }

            }
        }

        private void ReaderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Dispose();
        }
    }
}

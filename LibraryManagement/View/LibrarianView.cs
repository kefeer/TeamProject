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
                if (book.IsOwned)
                    dataGridView2.Rows[i].Cells[3].Value = "Yes";
                else
                    dataGridView2.Rows[i].Cells[3].Value = "No";
                if (book.IsOutdated)
                    dataGridView2.Rows[i].Cells[4].Value = "Yes";
                else
                    dataGridView2.Rows[i].Cells[4].Value = "No";
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
            catch (Exception ex)
            {
                MessageBox.Show("Please, select reader's row!");
            }
        }
    }
}

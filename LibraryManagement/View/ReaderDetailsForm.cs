using System;
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
                int i = 0;
                foreach (var book in Reader.BooksOwned)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = book.Name;
                }
            }
        }
        private void deleteReaderButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete " +
                                               "this reader?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Initializer.db.Readers.Remove(Reader);

        }

       
    }
}

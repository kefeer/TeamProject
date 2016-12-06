using System;
using System.Linq;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class MainForm : Form
    {
        public MainForm mainForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initializer.Main();
            ShowBooks();
            mainForm = this;
            
        }

        private void ShowBooks()
        {
            dataGridView1.Rows.Clear();

            int i = 0;
            foreach (var book in Initializer.db.Books)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = book.Name;
                dataGridView1.Rows[i].Cells[1].Value = book.Author;
                dataGridView1.Rows[i].Cells[2].Value = book.Genre;
                dataGridView1.Rows[i].Cells[3].Value = book.Year;
                dataGridView1.Rows[i].Cells[4].Value = book.Department;
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm form = new SignUpForm();
            form.ShowDialog();
        }

        private void linkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInForm form = new SignInForm(mainForm);
            form.ShowDialog();
        }
    }
}

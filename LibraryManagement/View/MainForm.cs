using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initializer.Main();
            ShowBooks();
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
    }
}

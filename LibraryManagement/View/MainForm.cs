using System;
using System.Linq;
using System.Threading;
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

            GreetingsForm greetingsForm = new GreetingsForm();
            greetingsForm.ShowDialog();

            mainForm = this;
            ShowBooks();

        }

        public void ShowBooks()
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
                dataGridView1.Rows[i].Cells[4].Value = book.NumberInStock;
                dataGridView1.Rows[i].Cells[5].Value = book.Department;


                //foreach (var deadline in book.DatesDeadline)
                //{
                //    if (deadline.Value < DateTime.Now)
                //    {
                //        book.IsOutdated = true;
                //        Initializer.db.SaveChanges();
                //    }
                //}

                i++;
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

        private void findButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            if (radioButton1.Checked)
            {
                dataGridView1.Rows.Clear();

                int i = 0;
                foreach (var book in Initializer.db.Books)
                {
                    if (book.Name.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = book.Name;
                        dataGridView1.Rows[i].Cells[1].Value = book.Author;
                        dataGridView1.Rows[i].Cells[2].Value = book.Genre;
                        dataGridView1.Rows[i].Cells[3].Value = book.Year;
                        dataGridView1.Rows[i].Cells[4].Value = book.NumberInStock;
                        dataGridView1.Rows[i].Cells[5].Value = book.Department;
                        i++;
                    }
                }
            }
            if (radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();

                int i = 0;
                foreach (var book in Initializer.db.Books)
                {
                    if (book.Author.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = book.Name;
                        dataGridView1.Rows[i].Cells[1].Value = book.Genre;
                        dataGridView1.Rows[i].Cells[2].Value = book.Author;
                        dataGridView1.Rows[i].Cells[3].Value = book.Year;
                        dataGridView1.Rows[i].Cells[4].Value = book.NumberInStock;
                        dataGridView1.Rows[i].Cells[5].Value = book.Department;
                       
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
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = book.Name;
                        dataGridView1.Rows[i].Cells[1].Value = book.Genre;
                        dataGridView1.Rows[i].Cells[2].Value = book.Author;
                        dataGridView1.Rows[i].Cells[3].Value  = book.Year;
                        dataGridView1.Rows[i].Cells[4].Value = book.NumberInStock;
                        dataGridView1.Rows[i].Cells[5].Value = book.Department;
                        
                        i++;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                ShowBooks();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Initializer.db.SaveChanges();
        }
    }
}

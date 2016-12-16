using System;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var book in Initializer.db.Books)
                {
                    if (book.Name == textBox1.Text)
                        throw new Exception("Such book is already in database!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("All fields must be filled!");
                return;
            }

            Initializer.db.Books.Add(new Book
            {
                Name = textBox1.Text,
                Author = textBox2.Text,
                Genre =  textBox3.Text,
                Year = textBox4.Text,
                Department = textBox5.Text,
                NumberInStock = int.Parse(maskedTextBox1.Text)

            });
            Initializer.db.SaveChanges();
            this.Dispose();
        }
    }
}

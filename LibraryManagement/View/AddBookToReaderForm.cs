using System;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class AddBookToReaderForm : Form
    {
        public Reader Reader;
        public AddBookToReaderForm(Reader reader)
        {
            InitializeComponent();
            Reader = reader;
        }

        private void AddBookToReaderForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("7 days");
            comboBox1.Items.Add("14 days");
            comboBox1.Items.Add("21 days");
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var book = Initializer.db.Books.SingleOrDefault(c => c.Name == textBox1.Text);
            if (book != null)
            {
                book.IsOwned = true;
                book.dateGiven = DateTime.Now;
                Reader.BooksOwned.Add(book);
                

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        book.dateMustBeReturned = book.dateGiven +
                                                  new TimeSpan(7, 0, 0);
                        break;
                    case 1:
                        book.dateMustBeReturned = book.dateGiven +
                                                  new TimeSpan(14, 0, 0);
                        break;
                    case 2:
                        book.dateMustBeReturned = book.dateGiven +
                                                  new TimeSpan(21, 0, 0);
                        break;
                }
                
                Initializer.db.SaveChanges();
                MessageBox.Show("Book has successfully been added to reader!");
                this.Close();
            }
            else
            {
                MessageBox.Show("There's no such book in the database!");
                this.Close();
            }
        }

      
    }
}

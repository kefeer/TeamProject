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
    public partial class SignInForm : Form
    {
        private MainForm mainForm;
        public SignInForm(MainForm mainform)
        {
            InitializeComponent();
            mainForm = mainform;
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var username = Initializer.db.
                    Librarians.SingleOrDefault(c => c.Username == textBox1.Text);
                if (username == null)
                {
                    MessageBox.Show("Username is not valid!");
                    return;
                }
                if (Initializer.db.
                    Librarians.SingleOrDefault(c => c.Username == textBox1.Text)
                    .Password == textBox2.Text)
                {
                    this.Dispose();
                    mainForm.Visible = false;
                    LibrarianView libView = new LibrarianView(mainForm, username);
                    libView.Show();
                }
                else
                {
                    MessageBox.Show("Password is not valid!");
                    return;
                }
            }
            else
            {
                var username = Initializer.db.
                   Readers.SingleOrDefault(c => c.Username == textBox1.Text);
                if (username == null)
                {
                    MessageBox.Show("Username is not valid!");
                    return;
                }
                if (Initializer.db.
                    Readers.SingleOrDefault(c => c.Username == textBox1.Text)
                    .Password == textBox2.Text)
                {
                    ReaderView readView = new ReaderView(mainForm, username);
                    this.Visible = false;
                    readView.Show();
                    
                }
                else
                {
                    MessageBox.Show("Password is not valid!");
                    return;
                }
            }
        }
    }
}

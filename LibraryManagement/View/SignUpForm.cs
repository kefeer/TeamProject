﻿using System;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Controller.Models;

namespace View
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name field is required!");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Surname field is required!");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Telephone number field is required!");
                return;
            }

            if (textBox7.Text != textBox8.Text)
            {
                MessageBox.Show("Passwords must match!");
                return;
            }

            if (radioButton1.Checked)
            {
                foreach (var reader in Initializer.db.Readers)
                {
                    if (textBox6.Text == reader.Username)
                    {
                        MessageBox.Show("User with such username already exists!\n" +
                                        "Please, choose another username.");
                        return;
                    }
                }


                Initializer.db.Readers.Add(new Reader
                {
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    DateOfBirth = textBox3.Text,
                    TelephoneNumber = textBox4.Text,
                    Email = textBox5.Text,
                    Username = textBox6.Text,
                    Password = textBox7.Text
                });
            }

            if (radioButton2.Checked)
            {

                foreach (var librarian in Initializer.db.Librarians)
                {
                    if (textBox6.Text == librarian.Username)
                    {
                        MessageBox.Show("Librarian with such username already exists!\n" +
                                        "Please, choose another username.");
                        return;
                    }
                }

                Initializer.db.Librarians.Add(new Librarian
                {
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    DateOfBirth = textBox3.Text,
                    TelephoneNumber = textBox4.Text,
                    Email = textBox5.Text,
                    Username = textBox6.Text,
                    Password = textBox7.Text

                });
            }
            Initializer.db.SaveChanges();
            MessageBox.Show("You have successfully created a new account!\n");
            this.Dispose();

        }
    }
}

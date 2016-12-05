using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void LibrarianView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Dispose();
        }
    }
}

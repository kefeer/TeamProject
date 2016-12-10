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
using Controller.Models;

namespace View
{
    public partial class ReaderView : Form
    {
        private Reader Reader;
        public ReaderView(Reader reader)
        {
            InitializeComponent();
            Reader = reader;
        }

        private void ReaderView_Load(object sender, EventArgs e)
        {

        }
    }
}

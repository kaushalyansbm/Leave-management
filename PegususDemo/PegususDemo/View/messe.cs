using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegususDemo.View
{
    public partial class messe : Form
    {
        public messe()
        {
            InitializeComponent();
        }
        public static string dname;
        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            dname = bunifuMetroTextbox1.Text;
            this.Hide();
            MessageBox.Show("file saved");

        }
    }
}

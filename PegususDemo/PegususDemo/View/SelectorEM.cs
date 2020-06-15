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
    public partial class SelectorEM : Form
    {
        public SelectorEM()
        {
            InitializeComponent();
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDashboard em = new EmployeeDashboard();
            em.ShowDialog();

        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerDashboard em = new ManagerDashboard();
            em.ShowDialog();

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelectorEM_Load(object sender, EventArgs e)
        {

        }

        private void SelectorEM_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to realy quit", "EXIT", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                Application.Exit();


            }
            else if (dialog == DialogResult.No)
            {

                e.Cancel = true;
            }

        }
    }
}

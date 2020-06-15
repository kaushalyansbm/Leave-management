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
    public partial class StLoad : Form
    {
        public StLoad()
        {
            InitializeComponent();
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);



            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                Login l = new Login();
                l.ShowDialog();

            }
        
    }

        private void StLoad_Load(object sender, EventArgs e)
        {



        }
    }
}

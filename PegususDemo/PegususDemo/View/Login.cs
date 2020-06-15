using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PegususDemo.model;
namespace PegususDemo.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        public static int SetValueForId;
        
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
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
        public static string Post;
        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "") {

                MessageBox.Show("All fields should filled");

            }
            else {
                SetValueForId = int.Parse(textBox1.Text);

                try
            {
                Dao con = new Dao();
                Employee emp = new Employee()
                {
                    Id = textBox1.Text,
                    Password = textBox2.Text


                };
                Manager man = new Manager()
                {
                    Id = textBox1.Text,
                    Password = textBox2.Text


                };
                Admin ad = new Admin()
                {
                    Id = textBox1.Text,
                    Password = textBox2.Text


                };
                con.Connect();
                   
                if (con.LogAdmin(ad) > 0)
                {
                    con.Disconnect();
                    this.Hide();
                    AdminDashboard adds = new AdminDashboard();
                    adds.ShowDialog();



                }
                con.Disconnect();
                con.Connect();
                if (con.LogEmployee(emp) > 0)
                {
                    con.Disconnect();
                    Post = "Employee";
                    this.Hide();

                    EmployeeDashboard adds = new EmployeeDashboard();
                    adds.ShowDialog();



                }

                con.Disconnect();
                con.Connect();
                if (con.LogManager(man) > 0)
                {
                    con.Disconnect();
                    Post = "Manager";
                    this.Hide();
                    SelectorEM s = new SelectorEM();
                    s.ShowDialog();

                    //ManagerDashboard adds = new ManagerDashboard();
                    //adds.ShowDialog();



                }
                con.Disconnect();
                con.Connect();
                if (con.LogEmployee(emp) == 0)
                {
                    con.Disconnect();
                    con.Connect();
                    if (con.LogManager(man) == 0)
                    {
                        con.Disconnect();
                        con.Connect();
                        if (con.LogAdmin(ad) == 0)
                        {
                            con.Disconnect();
                            con.Connect();

                            MessageBox.Show("try again", "wrong password");

                        }

                    }



                }

            }
            catch (Exception ex)
            {


            }
            }
        }

        private void TextBox2_OnValueChanged(object sender, EventArgs e)
        {
            textBox2.isPassword =true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PegususDemo.model;
namespace PegususDemo.View
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            panel5.Hide();
            label8.Hide();

            bunifuGradientPanel1.Hide();
            label8.Hide();
        }

        private void Label1_Click(object sender, EventArgs e)
        {


        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewEmployee an = new AddNewEmployee();
            an.ShowDialog();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEmployee ee = new EditEmployee();
            ee.ShowDialog();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label7.Text = DateTime.Now.ToLongDateString();
            label9.Text = DateTime.Now.ToLongTimeString();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        


          
            private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            
        }

        private void BunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label18_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton5_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            label8.Hide();
            panel5.Hide();
            bunifuGradientPanel1.Hide();
            Employee em = new Employee()
            {
                Designation = comboBox1.Text,
                Department = comboBox2.Text
            };

            Leave le = new Leave();

            le.SickCount = int.Parse(bunifuMaterialTextbox1.Text);
            le.CasualCount = int.Parse(bunifuMaterialTextbox2.Text);
            le.PergnancyCount = int.Parse(bunifuMaterialTextbox3.Text);
            le.ErenedCount = int.Parse(bunifuMaterialTextbox4.Text);
            le.NoPayCount = int.Parse(bunifuMaterialTextbox7.Text);
            if (checkBox1.CheckState == CheckState.Checked)
            {
                le.enablingS = 1;

            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                le.enablingCas = 1;

            }
            if (checkBox3.CheckState == CheckState.Checked)
            {
                le.enablingP = 1;

            }
            if (checkBox4.CheckState == CheckState.Checked)
            {
                le.enablingE = 1;

            }
            if (checkBox5.CheckState == CheckState.Checked)
            {
                le.enablingNP = 1;

            }

            if (radioButton5.Checked)
            {
                le.enablingEn =1;
                
            }
            else
            {

                le.enablingEn = 0;

            }
            Dao up = new Dao();
            up.Connect();
            up.UpdateLeaveCounts(le, em);
            MessageBox.Show("Settings were updated", "update");
            }

        private void BunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel1.Hide();
            panel5.Show();
            label8.Show();
        }

        private void BunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            label8.Hide();
            if ((comboBox1.Text == "Accountant" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Accountant" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Accountant" && comboBox2.Text == "Operation and maintenance") || (comboBox1.Text == "Accountant" && comboBox2.Text == "Sales and Marketing") || (comboBox1.Text == "Accountant" && comboBox2.Text == "Procurement"))
            {
                bunifuGradientPanel1.Hide();
                MessageBox.Show("Accountant is not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "ClaricalOfficers" && comboBox2.Text == "Finance") || (comboBox1.Text == "ClaricalOfficers" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "ClaricalOfficers" && comboBox2.Text == "Operation and maintenance") || (comboBox1.Text == "ClaricalOfficers" && comboBox2.Text == "Sales and Marketing") || (comboBox1.Text == "ClaricalOfficers" && comboBox2.Text == "Procurement"))
            {

                bunifuGradientPanel1.Hide();
                MessageBox.Show(" ClaricalOfficers is not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "HumanResourceManager" && comboBox2.Text == "Finance") || (comboBox1.Text == "HumanResourceManager" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "HumanResourceManager" && comboBox2.Text == "Operation and maintenance") || (comboBox1.Text == "HumanResourceManager" && comboBox2.Text == "Sales and Marketing") || (comboBox1.Text == "HumanResourceManager" && comboBox2.Text == "Procurement"))
            {

                bunifuGradientPanel1.Hide();
                MessageBox.Show("Human Resource Manager is not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "Sales Manager" && comboBox2.Text == "Finance") || (comboBox1.Text == "Sales Manager" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Sales Manager" && comboBox2.Text == "Operation and maintenance") || (comboBox1.Text == "Sales Manager" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Sales Manager" && comboBox2.Text == "Procurement"))
            {

                bunifuGradientPanel1.Hide();
                MessageBox.Show("Sales Manageris not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "Marketing Manager" && comboBox2.Text == "Finance") || (comboBox1.Text == "Marketing Manager" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Marketing Manager" && comboBox2.Text == "Operation and maintenance") || (comboBox1.Text == "Marketing Manager" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Marketing Manager" && comboBox2.Text == "Procurement"))
            {

                bunifuGradientPanel1.Hide();
                MessageBox.Show("Marketing Manager is not in   " + comboBox2.Text + "   Department");

            }

            else if ((comboBox1.Text == "Product Manager" && comboBox2.Text == "Finance") || (comboBox1.Text == "Product Manager" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Product Manager" && comboBox2.Text == "Operation and maintenance") || (comboBox1.Text == "Product Manager" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Product Manager" && comboBox2.Text == "Procurement"))
            {

                bunifuGradientPanel1.Hide();
                MessageBox.Show("Product Manager is not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "Technitian" && comboBox2.Text == "Finance") || (comboBox1.Text == "Technitian" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Technitian" && comboBox2.Text == "Sales and Marketing") || (comboBox1.Text == "Technitian" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Technitian" && comboBox2.Text == "Procurement"))
            {

                bunifuGradientPanel1.Hide();
                MessageBox.Show("Technitian is not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "Devision" && comboBox2.Text == "Finance") || (comboBox1.Text == "Devision" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Devision" && comboBox2.Text == "Sales and Marketing") || (comboBox1.Text == "Devision" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Devision" && comboBox2.Text == "Procurement"))
            {
                bunifuGradientPanel1.Hide();
                MessageBox.Show("Devision is not in   " + comboBox2.Text + "   Department");

            }
            else if ((comboBox1.Text == "Engineers" && comboBox2.Text == "Finance") || (comboBox1.Text == "Engineers" && comboBox2.Text == "Logistic and Maintenance") || (comboBox1.Text == "Engineers" && comboBox2.Text == "Sales and Marketing") || (comboBox1.Text == "Engineers" && comboBox2.Text == "HumanResourceManagement") || (comboBox1.Text == "Engineers" && comboBox2.Text == "Procurement"))
            {
                MessageBox.Show("Engineers are not in   " + comboBox2.Text + "   Department");

            }
            else { 

            bunifuGradientPanel1.Show();
            Employee em = new Employee()
            {
                Designation = comboBox1.Text,
                Department = comboBox2.Text
            };

            Leave l = new Leave();
            Dao f = new Dao();
            f.Connect();
            f.FindEmployeeCounts(em, l);
            comboBox1.Text = em.Designation;
            comboBox2.Text = em.Department;
            label24.Text = l.SickCount.ToString();
            label28.Text = l.NoPayCount.ToString();
            label25.Text = l.CasualCount.ToString();
            label29.Text = l.PergnancyCount.ToString();
            label26.Text = l.ErenedCount.ToString();

            bunifuMaterialTextbox1.Text = l.SickCount.ToString();
            bunifuMaterialTextbox7.Text = l.NoPayCount.ToString();
            bunifuMaterialTextbox2.Text = l.CasualCount.ToString();
            bunifuMaterialTextbox3.Text = l.PergnancyCount.ToString();
            bunifuMaterialTextbox4.Text = l.ErenedCount.ToString();
            if (l.enablingS == 1)
            {
                checkBox1.Checked = true;
                label30.Text = "enable";
            }
            else
            {

                label30.Text = "disable";
            }
            if (l.enablingCas == 1)
            {
                checkBox2.Checked = true;
                label31.Text = "enable";
            }
            else
            {

                label31.Text = "disable";

            }
            if (l.enablingP == 1)
            {
                checkBox3.Checked = true;
                label32.Text = "enable";
            }
            else
            {
                label32.Text = "disable";

            }
            if (l.enablingE == 1)
            {
                checkBox4.Checked = true;
                label33.Text = "enable";
            }
            else
            {
                label33.Text = "disable";

            }
            if (l.enablingNP == 1)
            {
                checkBox5.Checked = true;
                label35.Text = "enable";
            }
            else
            {

                radioButton6.Checked = true;
                label35.Text = "disable";
            }
            if (l.enablingEn == 1)
            {
                radioButton5.Checked = true;
                label34.Text = "enable";
            }
            else
            {

                radioButton6.Checked = true;
                label34.Text = "disable";
            }
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    } 
       
        
    }


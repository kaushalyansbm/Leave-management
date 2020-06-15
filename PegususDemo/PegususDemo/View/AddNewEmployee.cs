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
using System.IO;
using System.Text.RegularExpressions;
namespace PegususDemo.View
{
    public partial class AddNewEmployee : Form
    {
        public AddNewEmployee()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

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

     

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddNewEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();


            

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            AdminDashboard ee = new AdminDashboard();
            ee.ShowDialog();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void AddNewEmployee_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label7.Text = DateTime.Now.ToLongDateString();
            label6.Text = DateTime.Now.ToLongTimeString();
        }
        string marry;
        string imagepath;
        string gender;
        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (PIC!=null&&textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null && textBox7.Text != null && textBox9.Text != null && textBox10.Text != null && gender != null )
            {
                if ((comboBox2.Text == "Accountant" && comboBox1.Text == "HumanResourceManagement") || (comboBox2.Text == "Accountant" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Accountant" && comboBox1.Text == "Operation and maintenance") || (comboBox2.Text == "Accountant" && comboBox1.Text == "Sales and Marketing") || (comboBox2.Text == "Accountant" && comboBox1.Text == "Procurement"))
                {
                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Accountant is not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "ClaricalOfficers" && comboBox1.Text == "Finance") || (comboBox2.Text == "ClaricalOfficers" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "ClaricalOfficers" && comboBox1.Text == "Operation and maintenance") || (comboBox2.Text == "ClaricalOfficers" && comboBox1.Text == "Sales and Marketing") || (comboBox2.Text == "ClaricalOfficers" && comboBox1.Text == "Procurement"))
                {

                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show(" ClaricalOfficers is not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "HumanResourceManager" && comboBox1.Text == "Finance") || (comboBox2.Text == "HumanResourceManager" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "HumanResourceManager" && comboBox1.Text == "Operation and maintenance") || (comboBox2.Text == "HumanResourceManager" && comboBox1.Text == "Sales and Marketing") || (comboBox2.Text == "HumanResourceManager" && comboBox1.Text == "Procurement"))
                {

                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Human Resource Manager is not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "Sales Manager" && comboBox1.Text == "Finance") || (comboBox2.Text == "Sales Manager" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Sales Manager" && comboBox1.Text == "Operation and maintenance") || (comboBox2.Text == "Sales Manager" && comboBox1.Text == "HumanResourceManagement" )|| (comboBox2.Text == "Sales Manager" && comboBox1.Text == "Procurement"))
                {

                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Sales Manageris not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "Marketing Manager" && comboBox1.Text == "Finance") || (comboBox2.Text == "Marketing Manager" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Marketing Manager" && comboBox1.Text == "Operation and maintenance") || (comboBox2.Text == "Marketing Manager" && comboBox1.Text == "HumanResourceManagement") || (comboBox2.Text == "Marketing Manager" && comboBox1.Text == "Procurement"))
                {

                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Marketing Manager is not in   " + comboBox1.Text + "   Department");

                }

                else if ((comboBox2.Text == "Product Manager" && comboBox1.Text == "Finance") || (comboBox2.Text == "Product Manager" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Product Manager" && comboBox1.Text == "Operation and maintenance") || (comboBox2.Text == "Product Manager" && comboBox1.Text == "HumanResourceManagement") || (comboBox2.Text == "Product Manager" && comboBox1.Text == "Procurement"))
                {

                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Product Manager is not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "Technitian" && comboBox1.Text == "Finance") || (comboBox2.Text == "Technitian" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Technitian" && comboBox1.Text == "Sales and Marketing") || (comboBox2.Text == "Technitian" && comboBox1.Text == "HumanResourceManagement") || (comboBox2.Text == "Technitian" && comboBox1.Text == "Procurement"))
                {

                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Technitian is not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "Devision" && comboBox1.Text == "Finance") || (comboBox2.Text == "Devision" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Devision" && comboBox1.Text == "Sales and Marketing") || (comboBox2.Text == "Devision" && comboBox1.Text == "HumanResourceManagement") || (comboBox2.Text == "Devision" && comboBox1.Text == "Procurement"))
                {
                    //bunifuGradientPanel1.Hide();
                    MessageBox.Show("Devision is not in   " + comboBox1.Text + "   Department");

                }
                else if ((comboBox2.Text == "Engineers" && comboBox1.Text == "Finance") || (comboBox2.Text == "Engineers" && comboBox1.Text == "Logistic and Maintenance") || (comboBox2.Text == "Engineers" && comboBox1.Text == "Sales and Marketing") || (comboBox2.Text == "Engineers" && comboBox1.Text == "HumanResourceManagement") || (comboBox2.Text == "Engineers" && comboBox1.Text == "Procurement"))
                {
                    MessageBox.Show("Engineers are not in   " + comboBox1.Text + "   Department");

                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        marry = "married";



                    }
                    else
                    {
                        marry = "unmarried";
                    }

                    if (comboBox2.Text == "DeputyGenaralManager" || comboBox2.Text == "GenaralManager")
                    {
                        Manager man = new Manager()
                        {

                            Id = textBox3.Text,
                            FirstName = textBox1.Text,
                            LastName = textBox2.Text,
                            Password = textBox10.Text,
                            Email = textBox6.Text,
                            Department = comboBox1.Text,
                            Designation = comboBox2.Text,
                            Address = textBox5.Text,
                            Mobile = textBox7.Text,
                            Marriage = marry,
                            NumberOfChild = textBox9.Text,
                            Gender = gender,
                            Telephone = textBox4.Text,
                            image = textBox8.Text



                        };
                        Dao co = new Dao();
                        co.Connect();
                        co.EnterManager(man);
                        co.Disconnect();
                        MessageBox.Show("success fully inserted");
                        textBox3.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox10.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        textBox5.Text = "";
                        textBox7.Text = "";
                        textBox9.Text = "";
                        textBox4.Text = "";
                        textBox8.Text = "";
                        pictureBox3.Image = null;

                        co.Connect();
                        Leave le = new Leave();
                        co.FindManagerCounts(man,le);
                        co.Disconnect();
                        co.Connect();
                        co.insertAvailableCounts(man,le);
                        co.Disconnect();
                    }
                    else
                    {
                        Employee em = new Employee()
                        {
                            Id = textBox3.Text,
                            FirstName = textBox1.Text,
                            LastName = textBox2.Text,
                            Password = textBox10.Text,
                            Email = textBox6.Text,
                            Department = comboBox1.Text,
                            Designation = comboBox2.Text,
                            Address = textBox5.Text,
                            Mobile = textBox7.Text,
                            Marriage = marry,
                            NumberOfChild = textBox9.Text,
                            Gender = gender,
                            Telephone = textBox4.Text,
                            imageE = textBox8.Text
                        };
                        Dao co = new Dao();
                        co.Connect();
                        co.EnterEmployee(em);
                        co.Disconnect();
                        MessageBox.Show("success fully inserted");
                        textBox3.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox10.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        textBox5.Text = "";
                        textBox7.Text = "";
                        textBox9.Text = "";
                        textBox4.Text = "";
                        textBox8.Text = "";
                        checkBox1.Checked = false;
                        pictureBox3.Image = null;
                        co.Connect();
                        Leave le = new Leave();
                        co.FindEmployeeCounts(em, le);
                        co.Disconnect();
                        co.Connect();
                        co.insertAvailableCountsE(em, le);
                        co.Disconnect();

                    }
                }
            }
            else {
                

                    MessageBox.Show("all fields should filled");

                if (textBox3.Text.Length <= 0)
                {
                    errorProvider1.SetError(this.textBox3, "this field is empty");
                }
                if (textBox9.Text.Length <= 0)
                {
                    errorProvider2.SetError(this.textBox9, "this field is empty");
                }
                if (textBox1.Text.Length <= 0)
                {
                    errorProvider3.SetError(this.textBox1, "this field is empty");
                }
                if (textBox2.Text.Length <= 0)
                {
                    errorProvider4.SetError(this.textBox2, "this field is empty");
                }
                if (textBox5.Text.Length <= 0)
                {
                    errorProvider5.SetError(this.textBox5, "this field is empty");
                }
                if (textBox4.Text.Length <= 0)
                {
                    errorProvider6.SetError(this.textBox4, "this field is empty");
                }
                if (textBox4.Text.Length <= 0)
                {
                    errorProvider7.SetError(this.textBox4, "this field is empty");
                }
                if (textBox7.Text.Length <= 0)
                {
                    errorProvider8.SetError(this.textBox7, "this field is empty");
                }
                if (textBox10.Text.Length <= 0)
                {
                    errorProvider9.SetError(this.textBox10, "this field is empty");
                }
                string patern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{a-zA-Z]{2,9})$";
                if (Regex.IsMatch(textBox6.Text, patern))
                {
                    errorProvider10.Clear();

                }
                else
                {


                    errorProvider10.SetError(this.textBox6, "Enter valid email");
                    return;
                }
                if (textBox1.Text.Length <= 0)
                {
                    errorProvider11.SetError(this.textBox1, "this field is empty");
                }

            }
            

                
            
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        

        private void TextBox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Label18_Click(object sender, EventArgs e)
        {

        }
        string PIC;
        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog lg = new OpenFileDialog();
            lg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (lg.ShowDialog()==DialogResult.OK) {

                string picloc = lg.FileName.ToString();
                textBox8.Text = picloc;
                pictureBox3.ImageLocation = picloc;
                PIC = picloc;


            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){


                e.Handled = true;

            }
        }

        private void TextBox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {


                e.Handled = true;

            }
        }

        private void TextBox9_OnValueChanged(object sender, EventArgs e)
        {
          
        }

        private void TextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {


                e.Handled = true;

            }
        }

        private void TextBox6_Leave(object sender, EventArgs e)
        {

        }

        private void TextBox9_Leave(object sender, EventArgs e)
        {
            //if (textBox9.Text.Length <= 0)
            //{
            //    errorProvider1.SetError(this.textBox9, "this field is empty");
            //}
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            //    if (textBox1.Text.Length <= 0) {
            //        errorProvider1.SetError(this.textBox1,"this field is empty");
            //    }
            //
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            //    if (textBox2.Text.Length <= 0)
            //    {
            //        errorProvider1.SetError(this.textBox2, "this field is empty");
            //    }
            //
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
        }

        private void TextBox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            //if (textBox5.Text.Length <= 0)
            //{
            //    errorProvider1.SetError(this.textBox5, "this field is empty");
            //}
        }

        private void TextBox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
        //    if (textBox4.Text.Length <= 0)
        //    {
        //        errorProvider1.SetError(this.textBox4, "this field is empty");
        //    }
        }

        private void TextBox7_Leave(object sender, EventArgs e)
       {
        //    if (textBox7.Text.Length <= 0)
        //    {
        //        errorProvider1.SetError(this.textBox7, "this field is empty");
        //    }
        //
        }

        private void TextBox10_Leave(object sender, EventArgs e)
        {
            //    if (textBox10.Text.Length <= 0)
            //    {
            //        errorProvider1.SetError(this.textBox10, "this field is empty");
            //    }
            //
        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            EditEmployee ee = new EditEmployee();
            ee.ShowDialog();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard ee = new AdminDashboard();
            ee.ShowDialog();

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

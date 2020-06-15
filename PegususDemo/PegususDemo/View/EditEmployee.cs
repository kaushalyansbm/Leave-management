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
using MySql.Data.MySqlClient;

namespace PegususDemo.View
{
    public partial class EditEmployee : Form
    {
        public EditEmployee()
        {
            InitializeComponent();
            bunifuGradientPanel2.Hide();
            bunifuGradientPanel1.Hide();


        }
        public void loadTable()
        {

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myCon = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand("select id,department,designation,telephone,email,Address,mobile,numberchild from aurora.Employee;", myCon);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable ta = new DataTable();
                sda.Fill(ta);
                BindingSource BS = new BindingSource();
                BS.DataSource = ta;
                bunifuCustomDataGrid1.DataSource = BS;
                sda.Update(ta);
            }
            catch (Exception ex)
            {




            }








        }

        public void loadMTable()
        {

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myCon = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand("select id,department,designation,telephone,email,Address,mobile,numberchild from aurora.Manager;", myCon);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable ta = new DataTable();
                sda.Fill(ta);
                BindingSource BS = new BindingSource();
                BS.DataSource = ta;
                bunifuCustomDataGrid1.DataSource = BS;
                sda.Update(ta);
            }
            catch (Exception ex)
            {




            }








        }
        private void EditEmployee_FormClosing(object sender, FormClosingEventArgs e)
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
            try
            {
                this.Hide();
                AddNewEmployee an = new AddNewEmployee();
                an.ShowDialog();
            }
            catch (Exception ex) { }
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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard ad = new AdminDashboard();
            ad.ShowDialog();
        }

        private void BunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }
        string desig;
        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel1.Show();

            Manager man = new Manager()
            {
                Id = textBox1.Text
            };

            Dao cs = new Dao();
            cs.Connect();
            cs.FindM(man);
            if (man.Department != null)
            {
                

                comboBox1.Text = man.Department;
                comboBox2.Text = man.Designation;
                textBox2.Text = man.Telephone;
                textBox3.Text = man.Email;
                textBox4.Text = man.Address;
                textBox5.Text = man.Mobile;
                textBox6.Text = man.NumberOfChild;
                
                label15.Text = man.Department;
                label22.Text = man.Telephone;
                label23.Text = man.Email;
                label24.Text=man.Address;
                label25.Text = man.Mobile;
                label26.Text = man.NumberOfChild;
            }
            cs.Disconnect();
            Employee em = new Employee()
            {
                Id = textBox1.Text


            };
            cs.Connect();
            cs.FindEmployee(em);
            if (em.Department != null)
            {


                comboBox1.Text = em.Department;
                comboBox2.Text = em.Designation;
                textBox2.Text = em.Telephone;
                textBox3.Text = em.Email;
                textBox4.Text = em.Address;
                textBox5.Text = em.Mobile;
                textBox6.Text = em.NumberOfChild;


                label15.Text = em.Department;
                label22.Text = em.Telephone;
                label23.Text = em.Email;
                label24.Text = em.Address;
                label25.Text = em.Mobile;
                label26.Text = em.NumberOfChild;
            }
            cs.Disconnect();
            if (man.Department == null && em.Department == null) {


                label15.Text = "wrong id";
                label22.Text = "wrong id";
                label23.Text = "wrong id";
                label24.Text = "wrong id";
                label25.Text = "wrong id";
                label26.Text = "wrong id";

            }
        }
            
        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "DeputyGenaralManager" || comboBox2.Text == "GenaralManager") {
                Manager man = new Manager()
                {
                    Id = textBox1.Text,
                };

                Dao cs = new Dao();
                cs.Connect();
                cs.RemoveManager(man);
                MessageBox.Show("success fully removed employee");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";

                label15.Text = "data removed";
                label22.Text = "data removed";
                label23.Text = "data removed";
                label24.Text = "data removed";
                label25.Text = "data removed";
                label26.Text = "data removed";
            
        }
            else
            { 
                Employee em = new Employee()
            {
                Id = textBox1.Text,
            };

            Dao cs = new Dao();
            cs.Connect();
            cs.RemoveEmployee(em);
            MessageBox.Show("success fully removed employee");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";

                label15.Text = "data removed";
                label22.Text = "data removed";
                label23.Text = "data removed";
                label24.Text = "data removed";
                label25.Text = "data removed";
                label26.Text = "data removed";

            }
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
                if (comboBox2.Text== "DeputyGenaralManager" || comboBox2.Text == "GenaralManager") {


                    Manager man = new Manager()
                    {

                        Id = textBox1.Text,
                        Department = comboBox1.Text,
                        Designation = comboBox2.Text,
                        Telephone = textBox2.Text,
                        Email = textBox3.Text,
                        Address = textBox4.Text,
                        Mobile = textBox5.Text,
                        NumberOfChild = textBox6.Text
                    };

                    Dao ca = new Dao();
                    ca.Connect();
                    ca.UpdateManager(man);


                    MessageBox.Show("success fully updated employee");
                    textBox1.Text = man.Id;
                    textBox2.Text = man.Telephone;
                    textBox3.Text = man.Email;
                    textBox4.Text =man.Address;
                    textBox5.Text = man.Mobile;
                    textBox6.Text = man.NumberOfChild;
                    comboBox2.Text = man.Designation;
                    comboBox1.Text = man.Department;

                    



                    ca.Disconnect();
            


                }
                else { 

                Employee em = new Employee()
                {
                    Id = textBox1.Text,
                    Department = comboBox1.Text,
                    Designation = comboBox2.Text,
                    Telephone = textBox2.Text,
                    Email = textBox3.Text,
                    Address = textBox4.Text,
                    Mobile = textBox5.Text,
                    NumberOfChild = textBox6.Text

                };

                Dao cs = new Dao();
                cs.Connect();
                cs.UpdateEmployee(em);
                MessageBox.Show("success fully updated employee");
                textBox1.Text = em.Id;
                textBox2.Text = em.Telephone;
                textBox3.Text = em.Email;
                textBox4.Text = em.Address;
                textBox5.Text = em.Mobile;
                textBox6.Text = em.NumberOfChild;
                comboBox2.Text = em.Designation;
                comboBox1.Text = em.Department;


            }
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel2.Hide();



        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["id"].Value.ToString();
                comboBox1.Text = row.Cells["department"].Value.ToString();
                comboBox2.Text = row.Cells["designation"].Value.ToString();
                textBox2.Text = row.Cells["telephone"].Value.ToString();
                textBox3.Text = row.Cells["email"].Value.ToString();
                textBox4.Text = row.Cells["Address"].Value.ToString();
                textBox5.Text = row.Cells["mobile"].Value.ToString();
                textBox6.Text = row.Cells["numberchild"].Value.ToString();
            

            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label13.Text = DateTime.Now.ToLongDateString();
            label14.Text = DateTime.Now.ToLongTimeString();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BunifuCustomDataGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["id"].Value.ToString();
                comboBox1.Text = row.Cells["department"].Value.ToString();
                comboBox2.Text = row.Cells["designation"].Value.ToString();
                textBox2.Text = row.Cells["telephone"].Value.ToString();
                textBox3.Text = row.Cells["email"].Value.ToString();
                textBox4.Text = row.Cells["mobile"].Value.ToString();
                textBox5.Text = row.Cells["Address"].Value.ToString();
                textBox6.Text = row.Cells["numberchild"].Value.ToString();

                label15.Text = row.Cells["department"].Value.ToString();
                label22.Text = row.Cells["telephone"].Value.ToString();
                label23.Text = row.Cells["email"].Value.ToString();
                label24.Text = row.Cells["Address"].Value.ToString();
                label25.Text = row.Cells["mobile"].Value.ToString();
                label26.Text = row.Cells["numberchild"].Value.ToString();
                label4.Show();
                textBox1.Show();





            }

        }

        private void BunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton24_Click(object sender, EventArgs e)
        {
            
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel2.Show();
        }

        private void BunifuThinButton25_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "DeputyGenaralManager" || comboBox2.Text == "GenaralManager")
            {
                Manager man = new Manager()
                {
                    Id = textBox1.Text,
                };

                Dao cs = new Dao();
                cs.Connect();
                cs.RemoveManager(man);
                MessageBox.Show("success fully removed employee");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";


                label15.Text = "data removed";
                label22.Text = "data removed";
                label23.Text = "data removed";
                label24.Text = "data removed";
                label25.Text = "data removed";
                label26.Text = "data removed";

                loadMTable();
                bunifuGradientPanel2.Hide();
                bunifuGradientPanel1.Hide();

            }
            else
            {
                Employee em = new Employee()
                {
                    Id = textBox1.Text,
                };

                Dao cs = new Dao();
                cs.Connect();
                cs.RemoveEmployee(em);
                MessageBox.Show("success fully removed employee");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";

                label15.Text = "data removed";
                label22.Text = "data removed";
                label23.Text = "data removed";
                label24.Text = "data removed";
                label25.Text = "data removed";
                label26.Text = "data removed";
                bunifuGradientPanel2.Hide();
                bunifuGradientPanel1.Hide();


                loadTable();
            }
        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {


                e.Handled = true;

            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {


                e.Handled = true;

            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {


                e.Handled = true;

            }
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TextBox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
    }

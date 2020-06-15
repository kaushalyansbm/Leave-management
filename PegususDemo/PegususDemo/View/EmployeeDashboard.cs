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
using System.IO;


namespace PegususDemo.View
{
    public partial class EmployeeDashboard : Form
    {

        
        public EmployeeDashboard()
        {
            InitializeComponent();
            bunifuMaterialTextbox1.Text = (Login.SetValueForId).ToString();
            if (Login.Post == "Manager") {
                Dao ins = new Dao();
                ins.Connect();

                Manager em = new Manager()
                {
                  Id = bunifuMaterialTextbox1.Text
                  };
                ins.checkAvailabilityM(em);
                if (Dao.flower == 1) {
                    label8.Text= "You can't apply for leaves";
                    panel5.Hide();
                }
                ins.Disconnect();
                }
          
            if (Login.Post == "Employee")
            {
                Dao ins = new Dao();
                ins.Connect();

                Employee m = new Employee()
                {
                    Id = bunifuMaterialTextbox1.Text
                };
                ins.checkAvailability(m);
                if (Dao.flowere == 1)
                {
                    label8.Text = "You can't apply for leaves";
                    panel5.Hide();
                }

                ins.Disconnect();
            }
            try
            {


                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                myCon = new MySqlConnection(myConnection);


                selectCommand = new MySqlCommand("select * from aurora.Employee  where  id='" + (Login.SetValueForId).ToString() + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    byte[] im = (byte[])(myReader["image"]);
                    if (im == null)
                    {
                        pictureBox2.Image = null;
                    }
                    else
                    {

                        MemoryStream mst = new MemoryStream(im);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mst);
                    }

                }
                myCon.Close();
            }
            catch (Exception ex) { }

        }
        string one;
        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {



        }

        MySqlConnection myCon = null;
        MySqlDataReader myReader = null;
        MySqlCommand selectCommand = null;

        private void EmployeeDashboard_Load(object sender, EventArgs e)
        {
        }
        private void BunifuThinButton25_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuCustomTextbox1.Text == ""||comboBox1.Text=="") {
                    MessageBox.Show("all fields should filled");


                    
                }
                else { 
                Dao ins = new Dao();


                if (Login.Post == "Employee")
                {
                    ins.Connect();

                    Employee em = new Employee()
                    {
                        Id = bunifuMaterialTextbox1.Text


                    };
                    ins.takeGenderE(em);
                    ins.Disconnect();
                    if (em.Gender == "female")
                    {
                        ins.Connect();
                        DateTime std = bunifuDatepicker1.Value.Date;
                        DateTime end = bunifuDatepicker2.Value.Date;
                        TimeSpan dif = end - std;
                        int di = dif.Days;
                        if (di == 0)
                        {
                            di = 1;

                        }
                        else
                        {

                                di ++;

                            }


                        int dd = std.Day;
                        int mm = std.Month;
                        int yyyy = std.Year;

                        int dd1 = end.Day;
                        int mm1 = end.Month;
                        int yyyy1 = end.Year;


                        LeaveDetails ld = new LeaveDetails()
                        {
                            type = comboBox1.Text,
                            Description = bunifuCustomTextbox1.Text,
                            startdate = yyyy + "-" + mm + "-" + dd,
                            enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                            tempd = di

                        };
                        MessageBox.Show("Application was submited to the Manager");




                        ins.AskForLeave(ld, em);








                    }
                    else if (em.Gender == "male" && comboBox1.Text == "Pregnant Leave")
                    {
                        MessageBox.Show("As a male you cant use this leave type");

                    }
                    else {

                        ins.Connect();
                        DateTime std = bunifuDatepicker1.Value.Date;
                        DateTime end = bunifuDatepicker2.Value.Date;
                        TimeSpan dif = end - std;
                        int di = dif.Days;
                        if (di == 0)
                        {
                            di = 1;

                        }
                        else
                        {

                                di++;

                            }


                        int dd = std.Day;
                        int mm = std.Month;
                        int yyyy = std.Year;

                        int dd1 = end.Day;
                        int mm1 = end.Month;
                        int yyyy1 = end.Year;


                        LeaveDetails ld = new LeaveDetails()
                        {
                            type = comboBox1.Text,
                            Description = bunifuCustomTextbox1.Text,
                            startdate = yyyy + "-" + mm + "-" + dd,
                            enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                            tempd = di

                        };
                        MessageBox.Show("Application was submited to the Manager");




                        ins.AskForLeave(ld, em);






                    }





                }
                else
                {

                    ins.Connect();

                    Manager em = new Manager()
                    {
                        Id = bunifuMaterialTextbox1.Text,


                    };
                    ins.takeGenderM(em);
                    ins.Disconnect();
                    if (em.Gender == "female")
                    {
                        ins.Connect();
                        DateTime std = bunifuDatepicker1.Value.Date;
                        DateTime end = bunifuDatepicker2.Value.Date;
                        TimeSpan dif = end - std;
                        int di = dif.Days;
                        if (di == 0)
                        {
                            di = 1;

                        }
                        else
                        {

                                di ++;

                            }


                        int dd = std.Day;
                        int mm = std.Month;
                        int yyyy = std.Year;

                        int dd1 = end.Day;
                        int mm1 = end.Month;
                        int yyyy1 = end.Year;


                        LeaveDetails ld = new LeaveDetails()
                        {
                            type = comboBox1.Text,
                            Description = bunifuCustomTextbox1.Text,
                            startdate = yyyy + "-" + mm + "-" + dd,
                            enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                            tempd = di

                        };
                        MessageBox.Show("Application was submited to the Manager");




                        ins.AskForLeaveM(ld, em);








                    }
                    else if (em.Gender == "male" && comboBox1.Text == "Pregnant Leave")
                    {
                        MessageBox.Show("As a male you cant use this leave type");

                    }
                    else {

                        ins.Connect();
                        DateTime std = bunifuDatepicker1.Value.Date;
                        DateTime end = bunifuDatepicker2.Value.Date;
                        TimeSpan dif = end - std;
                        int di = dif.Days;
                        if (di == 0)
                        {
                            di = 1;

                        }
                        else
                        {

                                di ++;

                            }


                        int dd = std.Day;
                        int mm = std.Month;
                        int yyyy = std.Year;

                        int dd1 = end.Day;
                        int mm1 = end.Month;
                        int yyyy1 = end.Year;


                        LeaveDetails ld = new LeaveDetails()
                        {
                            type = comboBox1.Text,
                            Description = bunifuCustomTextbox1.Text,
                            startdate = yyyy + "-" + mm + "-" + dd,
                            enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                            tempd = di

                        };
                        MessageBox.Show("Application was submited to the Manager");




                        ins.AskForLeaveM(ld, em);






                    }





                }
                }
            }
            catch (Exception ex) { }

        }

        private void BunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeAceptance n = new EmployeeAceptance();
            n.ShowDialog();
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuCustomTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox1.Text.Length <= 0)
            {
                errorProvider1.SetError(this.bunifuCustomTextbox1, "this field is empty");
            }
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length <= 0)
            {
                errorProvider1.SetError(this.comboBox1, "this field is empty");
            }
        }

        private void BunifuThinButton25_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (bunifuCustomTextbox1.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("all fields should filled");
                    if (bunifuCustomTextbox1.Text.Length <= 0)
                    {
                        errorProvider1.SetError(this.bunifuCustomTextbox1, "this field is empty");
                    }
                    if (comboBox1.Text.Length <= 0)
                    {
                        errorProvider1.SetError(this.comboBox1, "this field is empty");
                    }
                }
                else
                {
                    Dao ins = new Dao();


                    if (Login.Post == "Employee")
                    {
                        ins.Connect();

                        Employee em = new Employee()
                        {
                            Id = bunifuMaterialTextbox1.Text


                        };
                        ins.takeGenderE(em);
                        ins.Disconnect();
                        if (em.Gender == "female")
                        {
                            ins.Connect();
                            DateTime std = bunifuDatepicker1.Value.Date;
                            DateTime end = bunifuDatepicker2.Value.Date;
                            TimeSpan dif = end - std;
                            int di = dif.Days;
                            if (di == 0)
                            {
                                di = 1;

                            }
                            else
                            {

                                di++;

                            }


                            int dd = std.Day;
                            int mm = std.Month;
                            int yyyy = std.Year;

                            int dd1 = end.Day;
                            int mm1 = end.Month;
                            int yyyy1 = end.Year;


                            LeaveDetails ld = new LeaveDetails()
                            {
                                type = comboBox1.Text,
                                Description = bunifuCustomTextbox1.Text,
                                startdate = yyyy + "-" + mm + "-" + dd,
                                enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                                tempd = di

                            };
                            MessageBox.Show("Application was submited to the Manager");




                            ins.AskForLeave(ld, em);








                        }
                        else if (em.Gender == "male" && comboBox1.Text == "Pregnant Leave")
                        {
                            MessageBox.Show("As a male you cant use this leave type");

                        }
                        else
                        {

                            ins.Connect();
                            DateTime std = bunifuDatepicker1.Value.Date;
                            DateTime end = bunifuDatepicker2.Value.Date;
                            TimeSpan dif = end - std;
                            int di = dif.Days;
                            if (di == 0)
                            {
                                di = 1;

                            }
                            else
                            {

                                di++;

                            }


                            int dd = std.Day;
                            int mm = std.Month;
                            int yyyy = std.Year;

                            int dd1 = end.Day;
                            int mm1 = end.Month;
                            int yyyy1 = end.Year;


                            LeaveDetails ld = new LeaveDetails()
                            {
                                type = comboBox1.Text,
                                Description = bunifuCustomTextbox1.Text,
                                startdate = yyyy + "-" + mm + "-" + dd,
                                enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                                tempd = di

                            };
                            MessageBox.Show("Application was submited to the Manager");




                            ins.AskForLeave(ld, em);






                        }





                    }
                    else
                    {

                        ins.Connect();

                        Manager em = new Manager()
                        {
                            Id = bunifuMaterialTextbox1.Text,


                        };
                        ins.takeGenderM(em);
                        ins.Disconnect();
                        if (em.Gender == "female")
                        {
                            ins.Connect();
                            DateTime std = bunifuDatepicker1.Value.Date;
                            DateTime end = bunifuDatepicker2.Value.Date;
                            TimeSpan dif = end - std;
                            int di = dif.Days;
                            if (di == 0)
                            {
                                di = 1;

                            }
                            else
                            {

                                di++;

                            }


                            int dd = std.Day;
                            int mm = std.Month;
                            int yyyy = std.Year;

                            int dd1 = end.Day;
                            int mm1 = end.Month;
                            int yyyy1 = end.Year;


                            LeaveDetails ld = new LeaveDetails()
                            {
                                type = comboBox1.Text,
                                Description = bunifuCustomTextbox1.Text,
                                startdate = yyyy + "-" + mm + "-" + dd,
                                enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                                tempd = di

                            };
                            MessageBox.Show("Application was submited to the Manager");




                            ins.AskForLeaveM(ld, em);








                        }
                        else if (em.Gender == "male" && comboBox1.Text == "Pregnant Leave")
                        {
                            MessageBox.Show("As a male you cant use this leave type");

                        }
                        else
                        {

                            ins.Connect();
                            DateTime std = bunifuDatepicker1.Value.Date;
                            DateTime end = bunifuDatepicker2.Value.Date;
                            TimeSpan dif = end - std;
                            int di = dif.Days;
                            if (di == 0)
                            {
                                di = 1;

                            }
                            else
                            {

                                di++;

                            }


                            int dd = std.Day;
                            int mm = std.Month;
                            int yyyy = std.Year;

                            int dd1 = end.Day;
                            int mm1 = end.Month;
                            int yyyy1 = end.Year;


                            LeaveDetails ld = new LeaveDetails()
                            {
                                type = comboBox1.Text,
                                Description = bunifuCustomTextbox1.Text,
                                startdate = yyyy + "-" + mm + "-" + dd,
                                enddate = yyyy1 + "-" + mm1 + "-" + dd1,
                                tempd = di

                            };
                            MessageBox.Show("Application was submited to the Manager");




                            ins.AskForLeaveM(ld, em);






                        }





                    }
                }
            }
            catch (Exception ex) { }

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton22_Click_1(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton24_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuThinButton22_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeAceptance em = new EmployeeAceptance();
            em.ShowDialog();
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PegususDemo.View
{
    public partial class ManagerDashboard : Form
    {
        public string keeper;
        public string dep;
        public ManagerDashboard()
        {

             Manager one = new Manager() {
                Id=Login.SetValueForId.ToString()
            };
            InitializeComponent();
            Dao X = new Dao();
            X.Connect();
            X.takeManagerDesignation(one);
            

            keeper = one.Designation;
            dep = one.Department;

            if(one.Designation== "GenaralManager") {

                loadTableM();

            }
            else
            {
             
                loadTable();
            }

            bunifuGradientPanel1.Hide();
        }
        string id;
        string referenc;
        MySqlConnection myCon = null;
        MySqlDataReader myReader = null;
        MySqlCommand selectCommand = null;
        string IdE;
        string type;
        int NOD;
        int availableCount;
        int changedCount;
        private void BunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];
                referenc = row.Cells["refer"].Value.ToString();
                type = row.Cells["type"].Value.ToString();
                string description = row.Cells["description"].Value.ToString();
                IdE = row.Cells["NIC"].Value.ToString();
                string lnmae = row.Cells["last name"].Value.ToString();
                string fname = row.Cells["first name"].Value.ToString();
                string from = row.Cells["from"].Value.ToString();
                string sickC = row.Cells["available sick leaves"].Value.ToString();
                string withoutC = row.Cells["available without pay leaves"].Value.ToString();
                string pregnantC = row.Cells["available pregnant leaves"].Value.ToString();
                string casualC = row.Cells["available casual leaves"].Value.ToString();
                string to = row.Cells["to"].Value.ToString();
                NOD = int.Parse(row.Cells["Number of dates"].Value.ToString());
                if (type == "Sick leaves") {
                    availableCount = int.Parse(sickC);
                    changedCount = availableCount - NOD;
                } else if (type == "Without Pay Leaves") {
                    availableCount = int.Parse(withoutC);
                    changedCount = availableCount - NOD;
                } else if (type == "Casual Leaves") {
                    availableCount = int.Parse(casualC);
                    changedCount = availableCount - NOD;
                } else if (type == "Pregnant Leave") {
                    availableCount = int.Parse(pregnantC);
                    changedCount = availableCount - NOD;
                }
                
                if (keeper == "DeputyGenaralManager")
                {
                    try
                    {


                        string myConnection = "datasource=localhost;port=3306;username=root;password=";
                        myCon = new MySqlConnection(myConnection);
                        

                        selectCommand = new MySqlCommand("select image from aurora.Employee  where  firstname='" + fname + "' and lastname='" + lnmae + "'; ", myCon);
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
                    label4.Text = fname;
                    label5.Text = lnmae;
                    label7.Text = type;
                    label9.Text = description;
                    label12.Text = from;
                    label10.Text = to;
                    label14.Text = NOD.ToString();
                    label18.Text = changedCount.ToString();
                    bunifuGradientPanel1.Show();
                    label23.Show();
               

                }
                else {
                    try
                    {


                        string myConnection = "datasource=localhost;port=3306;username=root;password=";
                        myCon = new MySqlConnection(myConnection);


                        selectCommand = new MySqlCommand("select image from aurora.Manager  where  firstname='" + fname + "' and lastname='" + lnmae + "'; ", myCon);
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
                    label4.Text = fname;
                    label5.Text = lnmae;
                    label7.Text = type;
                    label9.Text = description;
                    label12.Text = from;
                    label10.Text = to;
                    label14.Text = NOD.ToString();
                    label18.Text = changedCount.ToString();
                    bunifuGradientPanel1.Show();
   



                }
            }


        }
        public void loadTable()
        {

            Manager m = new Manager()
            {
                Id =Login.SetValueForId.ToString()



            };
            Dao tm = new Dao();
            tm.Connect();
            tm.takeManagerDepartment(m);
            tm.Disconnect();
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myCon = new MySqlConnection(myConnection);

                MySqlCommand cmdDataBase = new MySqlCommand("SELECT leavedescription.employeeid as 'NIC', leavedescription.leaveid as 'Refer', Employee.FIRSTNAME as 'first name', employee.lasTNAME as 'last name', leavedescription.description, leavedescription.type as 'type', leavedescription.fromd as 'from', leavedescription.tod as 'to', leavedescription.tempDif as 'Number of dates', Employee.sickC as 'available sick leaves', Employee.casualC as 'available casual leaves', Employee.pregnantC as 'available pregnant leaves', Employee.withoutC as 'available without pay leaves' FROM aurora.employee INNER JOIN aurora.leavedescription ON aurora.employee.id = aurora.leavedescription.employeeid where leavedescription.accept = '0' and employee.Department = '" + m.Department + "';", myCon);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable ta = new DataTable();
                sda.Fill(ta);
                BindingSource BS = new BindingSource();
                BS.DataSource = ta;
                bunifuCustomDataGrid1.DataSource = BS;
                sda.Update(ta);
                myCon.Close();
            }

            catch (Exception ex)
            {




            }








        }
        public void loadTableM()
        {

            Manager m = new Manager()
            {
                Id = Login.SetValueForId.ToString()



            };
            Dao tm = new Dao();
            tm.Connect();
            tm.takeManagerDepartment(m);
            tm.Disconnect();
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myCon = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand("SELECT  leavedescription.employeeid as 'NIC',leavedescription.leaveid as 'Refer',Manager.FIRSTNAME as 'first name',Manager.lasTNAME as 'last name',leavedescription.description,leavedescription.type as 'type', leavedescription.fromd as 'from', leavedescription.tod as 'to', leavedescription.tempDif as 'Number of dates',Manager.sickC as 'available sick leaves',Manager.casualC as 'available casual leaves',Manager.pregnantC as 'available pregnant leaves',Manager.withoutC as 'available without pay leaves' FROM aurora.Manager INNER JOIN aurora.leavedescription ON aurora.Manager.id = aurora.leavedescription.employeeid where leavedescription.accept = 0 and Manager.Department = '" + m.Department + "' and Manager.designation='DeputyGenaralManager';", myCon);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable ta = new DataTable();
                sda.Fill(ta);
                BindingSource BS = new BindingSource();
                BS.DataSource = ta;
                bunifuCustomDataGrid1.DataSource = BS;
                sda.Update(ta);
                myCon.Close();
            }
            catch (Exception ex)
            {




            }








        }
        int j;
        int empId;
        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            empId = int.Parse(IdE);
            LeaveDetails le = new LeaveDetails()
            {

                Leaveid =referenc
            };
            Dao del = new Dao();
            del.Connect();
            del.AcceptRequest(le);
            del.Disconnect();
            label16.Text = empId.ToString();
            label17.Text = changedCount.ToString();
            if (keeper == "DeputyGenaralManager")
            {
                if (type == "Sick leaves")
                {
                    del.Connect();
                    del.UpdateSickE(empId, changedCount);


                    del.Disconnect();
                }
                else if (type == "Without Pay Leaves")
                {
                    del.Connect();
                    del.UpdateWitoutE(empId, changedCount);
                    del.Disconnect();
                }
                else if (type == "Casual Leaves")
                {
                    del.Connect();
                    del.UpdateCasualE(empId, changedCount);
                    del.Disconnect();
                }
                else if (type == "Pregnant Leave")
                {
                    del.Connect();
                    del.UpdatePregnantE(empId, changedCount);
                    del.Disconnect();
                }
                MessageBox.Show("Accepted");
                loadTable();
                bunifuGradientPanel1.Hide();

            }
            else {

                if (type == "Sick leaves")
                {
                    del.Connect();
                    del.UpdateSickM(empId, changedCount);
                    del.Disconnect();
                    //del.
                }
                else if (type == "Without Pay Leaves")
                {
                    del.Connect();
                    del.UpdateWitoutM(empId, changedCount);
                    del.Disconnect();
                }
                else if (type == "Casual Leaves")
                {
                    del.Connect();
                    del.UpdateCasualM(empId, changedCount);
                    del.Disconnect();
                }
                else if (type == "Pregnant Leave")
                {
                    del.Connect();
                    del.UpdatePregnantM(empId, changedCount);
                    del.Disconnect();
                }
                MessageBox.Show("Accepted");
                loadTableM();
                bunifuGradientPanel1.Hide();


            }


        }
        int full;
        private void BunifuThinButton25_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        


        private void BunifuThinButton26_Click(object sender, EventArgs e)
        {

            LeaveDetails le = new LeaveDetails()
            {

                Leaveid =referenc
            };
            Dao del = new Dao();
            del.Connect();
            del.rejectRequest(le);
            del.Disconnect();
            //loadTable();
            
            if (keeper== "DeputyGenaralManager")
            {

                loadTable();

            }
            else
            {
                loadTableM();
            }

            bunifuGradientPanel1.Hide();
            MessageBox.Show("Rejected");

        }



        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports je = new Reports();
            je.ShowDialog();
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }
       private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton27_Click(object sender, EventArgs e)
        {


        }

        private void BunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
                
                }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
           // this.Hide();


        }

        private void BunifuThinButton22_Click_1(object sender, EventArgs e)
        {

        }

        private void ManagerDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton28_Click(object sender, EventArgs e)
        {

        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Reports re = new Reports();
            re.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

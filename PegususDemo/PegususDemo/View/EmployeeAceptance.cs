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
    public partial class EmployeeAceptance : Form
    {
        public EmployeeAceptance()
        {
            InitializeComponent();
            loadTable();
            Dao ac = new Dao();
            ac.Connect();
            string x = Login.SetValueForId.ToString();
            LeaveDetails ld = new LeaveDetails();
            ac.AcceptLeave(x, ld);
            if (ld.accept == "1")
            {
                richTextBox1.Text = "- You had apply for " + ld.type + " leave from " + ld.startdate + " to " + ld.enddate + " and it was accepted";
            }
            else if (ld.accept == "0")
            {
                richTextBox1.Text = "-You had apply for  " + ld.type + " leave from " + ld.startdate + " to " + ld.enddate + " and it was  not accepted.";
            }
            else {

                richTextBox1.Text = "-You have not apply for any leave recently ";

            }
            //=
            CalculateCount();
            //  .ToString();
        }

        public void loadTable()
        {

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myCon = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand("select  type,description,fromd,tod from aurora.leavedescription where accept="+1+" and employeeid="+Login.SetValueForId+";", myCon);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable ta = new DataTable();
                sda.Fill(ta);
                BindingSource BS = new BindingSource();
                BS.DataSource = ta;
                dataGridView1.DataSource = BS;
                sda.Update(ta);
                myCon.Close();
            }
            catch (Exception ex)
            {




            }








        }


        private void BunifuThinButton24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDashboard ed = new EmployeeDashboard();
            ed.ShowDialog();

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeAceptance_Load(object sender, EventArgs e)
        {

        }

        private void BunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDashboard n = new EmployeeDashboard();
            n.ShowDialog();
        }
        public static string id;
        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void CalculateCount() {
            Dao co = new Dao();
            if (Login.Post == "Employee")
            {
                Employee em = new Employee()
                {
                    Id = Login.SetValueForId.ToString()

                };

                co.Connect();
                co.checkAvailability(em);
                label11.Text = em.sickC.ToString();
                label10.Text = em.CasualC.ToString();
                if (em.Gender == "male")
                {
                    label9.Text = "not available for your gender";
                }
                else {

                    label9.Text = em.pregnantC.ToString();

                }
                label12.Text = em.WithoutC.ToString();
            }
            else {
                Manager m = new Manager()
                {
                    Id = Login.SetValueForId.ToString()

                };

                co.Connect();
                co.checkAvailabilityM(m);
                label11.Text = m.sickC.ToString();
                label10.Text = m.CasualC.ToString();
                if (m.Gender == "male")
                {
                    label9.Text = "not available for your gender";
                }
                else
                {

                    label9.Text = m.pregnantC.ToString();

                }
                label12.Text = m.WithoutC.ToString();


            }
        }
        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDashboard E = new EmployeeDashboard();
            E.ShowDialog();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}

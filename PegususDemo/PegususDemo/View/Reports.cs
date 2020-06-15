using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using PegususDemo.model;
using MySql.Data.MySqlClient;
namespace PegususDemo.View
{
    public partial class Reports : Form
    {
        public Reports()
        {
            
            InitializeComponent();
            //loadTableX();
        }

        private void BunifuFormFadeTransition1_TransitionEnd(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }
        MySqlConnection myCon = null;
        MySqlDataReader myReader = null;
        MySqlCommand selectCommand = null;
        
        public void loadTableX()
        {


            //































        }
        private void BunifuThinButton21_Click_1(object sender, EventArgs e)

        {
            messe mi = new messe();
            mi.ShowDialog();
            
            DateTime std = bunifuDatepicker1.Value.Date;
            DateTime end = bunifuDatepicker2.Value.Date;


            int dd = std.Day;
            int mm = std.Month;
            int yyyy = std.Year;

            int dd1 = end.Day;
            int mm1 = end.Month;
            int yyyy1 = end.Year;




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
                MySqlCommand cmdDataBase = new MySqlCommand("SELECT leavedescription.employeeid as 'NIC',Employee.FIRSTNAME as 'first name',employee.lasTNAME as 'last name',leavedescription.description,leavedescription.type as 'type', leavedescription.fromd as 'from', leavedescription.tod as 'to', leavedescription.tempDif as 'Number of dates',Employee.sickC as 'available sick leaves',Employee.casualC as 'available casual leaves',Employee.pregnantC as 'available pregnant leaves',Employee.withoutC as 'available without pay leaves' FROM aurora.employee INNER JOIN aurora.leavedescription ON aurora.employee.id = aurora.leavedescription.employeeid where leavedescription.accept=1 and employee.Department='" + m.Department + "' and tod between '" + yyyy + "-" + mm + "-" + dd + "' and '" + yyyy1 + "-" + mm1 + "-" + dd1 + "' ;", myCon);
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







            Manager mw = new Manager() {
                Id = Login.SetValueForId.ToString()

            };
           Dao d = new Dao();
            d.Connect();
            d.takeManagerDepartment(m);
            d.Disconnect();

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(messe.dname+".pdf", FileMode.Create));
            doc.Open();
            Paragraph pa = new Paragraph("\t"+"This report include all the details related to "+m.Department+"department.\n"+"\n\n\n");
            doc.Add(pa);
            PdfPTable table = new PdfPTable(bunifuCustomDataGrid1.Columns.Count);
            for (int j = 0; j < bunifuCustomDataGrid1.Columns.Count; j++) {

                table.AddCell(new Phrase(bunifuCustomDataGrid1.Columns[j].HeaderText));


            }
            table.HeaderRows = 1;

            for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
            {
                for (int k = 0; k < bunifuCustomDataGrid1.Columns.Count; k++) {
                if (bunifuCustomDataGrid1[k, i].Value != null)
                {


                        table.AddCell(new Phrase(bunifuCustomDataGrid1[k, i].Value.ToString()));

                }

                }



            }
            doc.Add(table);
            doc.Close();

                
                
                }  

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerDashboard mn = new ManagerDashboard();
            mn.ShowDialog();

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void Reports_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}

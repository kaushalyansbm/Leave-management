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
namespace PegususDemo.View
{
    public partial class AcceptReject : Form
    {
        public AcceptReject()
        {
            InitializeComponent();
            loadTable();
        }

        public void loadTable()
        {

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myCon = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand("SELECT type as 'leave type',description as 'description',fromd as 'from',tod as 'to'  FROM aurora.leavedescription where accept='0';", myCon);
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
        private void AcceptReject_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace EXPRT
{
    public partial class ViewExpRep : Form
    {
        public ViewExpRep()
        {
            InitializeComponent();
        }

        private void ViewExpRep_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DB_UTILS.Select();

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainServiceReference.MainServiceSoapClient client = new MainServiceReference.MainServiceSoapClient("MainServiceSoap");
            DataSet d= client.GetReports(ssn_box.Text, 1);
            d.Tables[0].Columns["first_name"].ColumnName = "Manager's First Name";
            d.Tables[0].Columns["last_name"].ColumnName = "Manager's Last Name";
            dataGridView1.DataSource = d.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            Hide();
            f.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

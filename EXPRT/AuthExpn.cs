using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXPRT
{
    public partial class AuthExpn : Form
    {
        public AuthExpn()
        {
            InitializeComponent();
        }

        private void AuthExpn_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment has been authorized for Report " + id_box.Text + "!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainServiceReference.MainServiceSoapClient client = new MainServiceReference.MainServiceSoapClient("MainServiceSoap");
            DataSet d = client.GetReports(dept_box.Text, 3);
            d.Tables[0].Columns["first_name"].ColumnName = "Employee's First Name";
            d.Tables[0].Columns["last_name"].ColumnName = "Employee's Last Name";
            dataGridView1.DataSource = d.Tables[0];
        }
    }
}

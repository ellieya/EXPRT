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
    public partial class UpdateExpn : Form
    {
        public UpdateExpn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainServiceReference.MainServiceSoapClient client = new MainServiceReference.MainServiceSoapClient("MainServiceSoap");
            int report_id = Int32.Parse(textBox1.Text);
            client.Update(report_id);
            MessageBox.Show("You have approved the expense report!");
            dataGridView1.DataSource = client.GetReports(ssn_box.Text, 2).Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainServiceReference.MainServiceSoapClient client = new MainServiceReference.MainServiceSoapClient("MainServiceSoap");
            DataSet d = client.GetReports(ssn_box.Text, 2);
            d.Tables[0].Columns["first_name"].ColumnName = "Employee's First Name";
            d.Tables[0].Columns["last_name"].ColumnName = "Employee's Last Name";
            dataGridView1.DataSource = d.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class AddExpRep : Form
    {
        public AddExpRep()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy'-'MM'-'dd hh':'mm':'ss";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainServiceReference.MainServiceSoapClient client = new MainServiceReference.MainServiceSoapClient("MainServiceSoap");
            int manager_id = Int32.Parse(textBox2.Text);
            decimal price = Decimal.Parse(textBox5.Text);
            
            client.Insert(textBox1.Text, manager_id, textBox3.Text, textBox4.Text, dateTimePicker1.Text, price);
            MessageBox.Show("Expense Report Added!");
            Menu f = new Menu();
            Hide();
            f.ShowDialog();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

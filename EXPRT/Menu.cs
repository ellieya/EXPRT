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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void addExpRep_Click(object sender, EventArgs e)
        {
            AddExpRep f = new AddExpRep();
            Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewExpRep f = new ViewExpRep();
            Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

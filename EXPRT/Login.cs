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
using System.Security.Cryptography;
using EXPRT;

namespace EXPRT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            passwordBox.PasswordChar = '*';
            passwordBox.MaxLength = 20;
        }
        //Sha1 Encrpytion
        string base64(string input)
        {
            string base64Encoded;
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
            base64Encoded = System.Convert.ToBase64String(data);
            return base64Encoded;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MainServiceReference.MainServiceSoapClient client = new MainServiceReference.MainServiceSoapClient("MainServiceSoap");

            int type = client.Login(usernameBox.Text, passwordBox.Text);
            if (type == 1)
            {
                //creates the second form and displays it
                Menu f = new Menu();
                Hide();
                f.ShowDialog();
            }
            else if (type == 2)
            {
                UpdateExpn f = new UpdateExpn();
                Hide();
                f.ShowDialog();
            }
            else if (type == 3)
            {
                AuthExpn f = new AuthExpn();
                Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or Password Is Not Correct ...Please Try Again!");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
        
}


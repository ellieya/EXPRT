using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace EPRT
{
    class DB_UTILS
    {
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static void Select(string amount, string table, string col_name)
        {

            string connect = "server=localhost;database=expense_report_sys;uid=root;pwd=Virfidelis2016!;";

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = String.Format("SELECT {0} FROM {1}", amount, table);
                    cmd.CommandText = x;
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine(reader.GetString(col_name));
                        }
                    }


                }

            }

        }

        public static void Insert(string date, string reason, string type, int manager_id, string ssn, decimal price)
        {

            string connect = "server=localhost;database=expense_report_sys;uid=root;pwd=Virfidelis2016!;";

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {

                    string x = String.Format(
                        "INSERT INTO reports " +
                        "(ssn, manager_id, expense_type, expense_reason, date_filed, price) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5} )", ComputeSha256Hash(ssn), manager_id, type, reason, date, price);

                    cmd.CommandText = x;
                    cmd.ExecuteNonQuery();

                }

            }

        }

        public static void Update(int report_id)
        {

            string connect = "server=localhost;database=expense_report_sys;uid=root;pwd=Virfidelis2016!;";

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = String.Format(
                        "UPDATE reports SET approved =0 " +
                        "WHERE report_id = {0}", report_id);
                        
                    cmd.CommandText = x;
                    cmd.ExecuteNonQuery();

                }

            }

        }

        public static string Login(string username, string password)
        {

            string connect = "server=localhost;database=expense_report_sys;uid=root;pwd=Virfidelis2016!;";

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = String.Format(
                        "SELECT username, password " +
                        "FROM users WHERE username = '{0}' AND password ='{1}'",username, ComputeSha256Hash(password));

                    cmd.CommandText = x;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return password;
                        }
                        else
                        {
                            return "ERROR!";
                        }
                    }

                }

            }

        }

    }
    
   


}

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace WcfService1
{
    class DB_UTILS
    {
        private static string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "connectioncredentials.txt");
        private static string connect = System.IO.File.ReadAllText(path);

        private static string ComputeSha256Hash(string rawData)
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

        public static MySqlDataReader Select(string values, string table)
        {

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = String.Format("SELECT {0} FROM {1}", values, table);
                    cmd.CommandText = x;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            return reader;
                        }
                        else
                        {
                            return null;
                        }
                    }


                }

            }

        }

        public static bool Insert(string ssn, int manager_id, string type, string reason, string date, decimal price)
        {

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

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            conn.Close();
                            return true;
                        }
                        else
                            return false;
                    }

                }

            }

        }

        public static int Update(int report_id)
        {

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = String.Format(
                        "UPDATE reports SET approved = 1 " +
                        "WHERE report_id = {0}", report_id);
                        
                    cmd.CommandText = x;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        return reader.RecordsAffected;
                    }

                }

            }

        }

        public static int Login(string username, string password)
        {

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                        string x = String.Format(
                        "SELECT access " +
                        "FROM users WHERE username = '{0}' AND password ='{1}'", username, ComputeSha256Hash(password));

                    cmd.CommandText = x;
                    if (cmd.ExecuteScalar() == null)
                    {
                        return -1;
                    }
                    return (int)cmd.ExecuteScalar();
                    

                }

            }

        }
        public static DataSet GetReports(string identifier, int flag)
        {

            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = "";
                    
                    if (flag == 1)
                    {
                         x = String.Format(
                            "SELECT report_id, managers.first_name, managers.last_name,expense_type, expense_reason, date_filed, approved, price " +
                            "FROM reports, managers " +
                            "WHERE reports.manager_id = managers.manager_id AND ssn = '{0}' ", ComputeSha256Hash(identifier));
                    }
                    if (flag == 2)
                    {
                        x = String.Format(
                          "SELECT employees.first_name, employees.last_name,"+
                          "report_id, expense_type, expense_reason, date_filed, approved, price "+
                          "FROM employees, reports " +
                          "WHERE employees.ssn = reports.ssn "+
                          "AND reports.manager_id = '{0}'", identifier);
                    }
                    if (flag == 3)
                    {
                        x = String.Format(
                          "SELECT employees.first_name, employees.last_name," +
                          "report_id, expense_type, expense_reason, date_filed, approved, price " +
                          "FROM employees, reports, managers " +
                          "WHERE employees.ssn = reports.ssn " +
                          "AND reports.manager_id = managers.manager_id " +
                          "AND managers.department = '{0}'", identifier);
                    }

                    cmd.CommandText = x;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(x, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);                        
                        return ds;
                    }
                }
            }
        } 
    }
    
   


}

using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EPRT
{
    class DB_UTILS
    {
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

        public static void Insert(string date, string reason, string type, int manager_id, string ssn)
        {

            string connect = "server=localhost;database=expense_report_sys;uid=root;pwd=Virfidelis2016!;";

            using (var conn = new MySqlConnection(connect))
            {
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    string x = String.Format(
                        "INSERT INTO reports " +
                        "(ssn, manager_id, expense_type, expense_reason, date_filed) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}' )", ssn, manager_id, type, reason, date);

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
    }
    
   


}

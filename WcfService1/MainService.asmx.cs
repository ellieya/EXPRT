using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WcfService1
{
    /// <summary>
    /// Summary description for MainService
    /// </summary>
    [WebService(Namespace = "https://wcfservice120191208111035.azurewebsites.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MainService : System.Web.Services.WebService
    {

        [WebMethod]
        public int Login(String username, String password)
        {
            return DB_UTILS.Login(username, password);
        }

        [WebMethod]
        public DataSet GetReports(String identifier, int flag)
        {
            return DB_UTILS.GetReports(identifier, flag);
        }

        [WebMethod]
        public bool Insert(string ssn, int manager_id, string type, string reason, string date, decimal price)
        {
            return DB_UTILS.Insert(ssn, manager_id, type, reason, date, price);
        }

        [WebMethod]
        public int Update(int report_id)
        {
            return DB_UTILS.Update(report_id);
        }


    }
}

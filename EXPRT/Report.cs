using System;
namespace EPRT
{
    public class Report
    {
        Employee filer;
        Manager approver;
        int id;
        string type;
        string reason;
        string date;
        decimal price;
        bool approved;


        public Report(Employee e, Manager m, int i, string t, string r, string d, decimal p, bool a)
        {
            filer = e;
            approver = m;
            id = i;
            type = t;
            reason = r;
            date = d;
            price = p;
            approved = a;
        }

        public Employee Filer
        {
            get { return filer; }
            set { filer = value; }
        }

        public Manager Approver
        {
            get { return approver; }
            set { approver = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }
    }
}

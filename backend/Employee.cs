using System;
namespace EPRT
{
    public class Employee : Person
    {
        string ssn;
        int manager_id;


        public Employee(string fn, string ln, string em, string d, string ss, int m) : base(fn,ln,em,d)
        {
            ssn = ss;
            manager_id = m;
        }

        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        public int ManagerID
        {
            get { return manager_id; }
            set { manager_id = value; }
        }
      

    }
}

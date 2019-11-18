using System;
namespace EPRT
{
    public class Manager : Person
    {
        int numEmps;
        int manager_id;

        public Manager(string fn, string ln, string em, string d, int num, int m) : base(fn, ln, em, d)
        {
            numEmps = num;
            manager_id = m;
        }

        public int NumEmps
        {
            get { return numEmps; }
            set { numEmps = value; }
        }

        public int ManagerID
        {
            get { return manager_id; }
            set { manager_id = value; }
        }

    }
}

using System;
namespace EPRT
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string email;
        private string department;


        public Person()
        {
        }

        public Person (string fn, string ln, string em, string d)
        {
            firstName = fn;
            lastName = ln;
            email = em;
            department = d;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

    }
}

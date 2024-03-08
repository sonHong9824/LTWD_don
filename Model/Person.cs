using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market.Model
{
    public class Person
    {
        private int ID;
        private string Name;
        private string Address;
        private string Phone_number;
        private string Email;
        string CMND;
        string Sex;
        string DoB;
        string Avatar_source; // Set avatar

        public Person()
        {
        }

        public Person(int iD, string name, string address, string phone_number, string email, string cMND, string sex, string doB, string avatar_source)
        {
            ID1 = iD;
            Name1 = name;
            Address1 = address;
            Phone_number1 = phone_number;
            Email1 = email;
            CMND1 = cMND;
            Sex1 = sex;
            DoB1 = doB;
            Avatar_source1 = avatar_source;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Address1 { get => Address; set => Address = value; }
        public string Phone_number1 { get => Phone_number; set => Phone_number = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string CMND1 { get => CMND; set => CMND = value; }
        public string Sex1 { get => Sex; set => Sex = value; }
        public string DoB1 { get => DoB; set => DoB = value; }
        public string Avatar_source1 { get => Avatar_source; set => Avatar_source = value; }
    }
}
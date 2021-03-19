using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoQuocTuan_5951071118.Models
{
    public class Employee
    {
        private string department = "";
        private int id = 0;
        private string name = "";
        private string city = "";
        private string state = "";
        private string country = "";
        private string flag = "";

        public string Department { get => department; set => department = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Country { get => country; set => country = value; }
        public string Flag { get => flag; set => flag = value; }
    }
}

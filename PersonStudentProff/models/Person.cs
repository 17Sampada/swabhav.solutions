using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentProff.models
{
    internal class Person
    {
        public int Id { get; set; }

        public string Add { get; set; }

        public DateTime Dob { get; set; }

        public Person()
        {
            
        }

        public Person(int id,string add, DateTime dob)
        {
            Id = id;
            Add = add;
            Dob = dob;

            
        }

        public virtual string PrintDetails()
        {
            return $"Person Id:{Id}\n" +
                $"Add:{Add}\n" +
                $"Date of birth:{Dob.ToString("MM/dd/yyyy")}";
        }
    }
}

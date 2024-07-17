using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentProff.models
{
    internal class Professor: Person
    {
        public double Salary {  get; set; }
        
        public double Bonus { get; set; }

        public Professor()
        {
            
        }
        public Professor(int id,string add, DateTime dob, double salary,double bonus) :base(id,add, dob)
        {
            Salary = salary;
            
            Bonus = bonus;
        }


        public double CalculateSalary()
        {
            return Salary + Bonus;
        }

        public override string PrintDetails()
        {
            return $"{base.PrintDetails()}\nSalary:{Salary}\n" +
                $"Bonus:{Bonus}\n" +
                $"Total Salary:{CalculateSalary()}";
        }
    }
}

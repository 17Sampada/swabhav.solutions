using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentProff.models
{
    internal class Student:Person
    {
        public string Branch { get; set; }
        public Student()
        {
            

        }

        public Student(int id,string add, DateTime dob, string branch):base (id,add,dob)
        {
            Branch = branch;
        }

        public override string PrintDetails()
        {
            return $"{base.PrintDetails()}\nBranch: {Branch}";
        }
    }
}

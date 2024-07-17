using System.Runtime.ConstrainedExecution;
using PersonStudentProff.models;

namespace PersonStudentProff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(101, "Raj ratna Park, Thane west", new DateTime (2000,01,17));
            Professor professor = new Professor(102,"Swastik park, Maharashtra", new DateTime(1985,08,26), 567890,80000);
            Student student = new Student(102,"Swami Society,dadar", new DateTime(2006,07,20), "Computer");

            PrintEmplyoeeDetails(person);
            PrintEmplyoeeDetails(professor);
            PrintEmplyoeeDetails(student);

        }

        static void PrintEmplyoeeDetails(Person person)
        {
            Console.WriteLine($"==========================Role: {person.GetType().Name}============================");
            Console.WriteLine(person.PrintDetails());
        }
    }

}

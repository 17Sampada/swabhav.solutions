using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        static int DEFAULT_HEIGHT = 5;
        static int DEFAULT_WEIGHT = 50;

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = DEFAULT_HEIGHT;
            Weight = DEFAULT_WEIGHT;

        }


        public Person(int id, string name, int age, double height, double weight) : this(id, name, age)
        {
            Height = height;
            Weight = weight;

        }

        public double CalculateBmi()
        {
            return Weight / (Height * Height);
        }

        public string GetBodyType()
        {
            double bmi = CalculateBmi();

            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                return "Normal weight";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                return "Overweight";
            }
            else
            {
                return "Obesity";
            }

        }

        public override string ToString()
        {
            return $"Person ID: {Id}\n" +
                $"Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Height:{Height}\n" +
                $"Weight:{Weight}\n"+
                $"BMI: {CalculateBmi()}\n"+
                $"Body Type: {GetBodyType()}";
        }
    }
}   











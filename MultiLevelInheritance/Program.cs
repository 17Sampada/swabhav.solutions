using MultiLevelInheritance.models;
using static MultiLevelInheritance.models.Animal;

namespace MultiLevelInheritance
{
    internal class Program
    {
            static void Main(string[] args)
            {

            Dog myDog = new Dog();

           
            myDog.Bark();   
            myDog.Walk();   
            myDog.Eat();   
            myDog.Sleep();   
        }
        
    }

}
    


using ClassVsStruct.models;

namespace ClassVsStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Sampada", 22);
            person.Introduce();

            Point point = new Point(10, 20);
            point.Display();

            
            Point anotherPoint = point;
            anotherPoint.X = 30;
            anotherPoint.Display(); 
            point.Display();
        }
    }
}

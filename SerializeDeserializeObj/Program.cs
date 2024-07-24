using System.Configuration;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Channels;
using SerializeDeserializeObj.models;

namespace SerializeDeserializeObj
{
    internal class Program
    {
        static string path = ConfigurationManager.AppSettings["filePath"].ToString();


        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person(01,"Sampada","sapada@gmailcom"),
                new Person(02,"swamini","swmini@gmail.com"),
                new Person(03,"swati","swati@gmailcom"),
                new Person(04,"aagya","aagya@gmail.com"),
                new Person(05, "roshni","roshni@gmail.com")
            };

           // SerializeObjects(persons);
            var persons1=Deserialize();
            persons1.ForEach(person => Console.WriteLine(person));

        }

        static void SerializeObjects(List<Person> persons)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {


                sw.WriteLine(JsonSerializer.Serialize(persons));
                Console.WriteLine("Serialized Objects");
                Console.WriteLine("Persons Objects Written To File");
            }
        }
        static List<Person> Deserialize()
        {
            if (!File.Exists(path))
                return new List<Person>();
 
            using (StreamReader sr = new StreamReader(path))
            {
                List<Person> persons = JsonSerializer.Deserialize<List<Person>>(sr.ReadToEnd());
                return persons;
            }
        }
    }
}

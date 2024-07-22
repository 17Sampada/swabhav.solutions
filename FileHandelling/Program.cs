using System.IO;
namespace FileHandelling
{
    internal class Program
    {
        

            
            static void Main(string[] args)
            {
                string file1 = @"D:\AproSCM'24\FileHandelling\FileHandelling.txt";
                
                Console.WriteLine("Reading File using File.ReadAllText()");
                if (File.Exists(file1))
                {
                    string str = File.ReadAllText(file1);
                    Console.WriteLine(str);
                }

                File.WriteAllText("D:\\AproSCM'24\\FileHandelling\\FileHandelling.txt", "hello world 2");

            

               
        }
        
    }
}

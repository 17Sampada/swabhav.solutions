using System.IO;

namespace FileHandellingHtml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\sampada.bhadane\Desktop\filehandellinghtml.html";

            Console.WriteLine("Reading File using File.ReadAllLines()");
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string ln in lines)
                    Console.WriteLine(ln);
            }

            string htmlContent = "<!DOCTYPE html>\n" +
                             "<html>\n" +
                             "<head>\n" +
                             "<title>My HTML Page</title>\n" +
                             "</head>\n" +
                             "<body>\n" +
                             "<h1>Hello, Sampada!</h1>\n" +
                             "</body>\n" +
                             "</html>";

            string htmlFilePath = "C:\\Users\\sampada.bhadane\\Desktop\\filehandellinghtml.html";


            File.WriteAllText(htmlFilePath, htmlContent);

            Console.WriteLine($"HTML content written to {htmlFilePath}");
            using (StreamWriter sw = new StreamWriter(htmlFilePath, true))
            {
                sw.WriteLine("hello first");
                sw.WriteLine("text written in file");
            }
        }
        
    }
}


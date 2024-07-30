using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.models;

namespace MovieLibrary.Services
{
    public class DataSerializer
    {
        //static string path = ConfigurationManager.AppSettings["filePath"].ToString();
        static string path = @"D:\AproSCM'24\FInalLayeredMovieApp\MovieLibrary\Assets";

        public static void SerializeMovies(List<Movie> movies)
        {
            using (StreamWriter sr = new StreamWriter(path, false))
            {
                sr.WriteLine(JsonSerializer.Serialize(movies));
            }
        }

        public static List<Movie> DeserializeMovies()
        {
            if (!File.Exists(path))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(path))
            {
                List<Movie> accounts = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return accounts;
            }
        }
    }
}

using System.Security.Principal;
using MiniProject1.Models;

namespace MiniProject1
{
    internal class Program
    {
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            
            DisplayMenu();
        }



        static void DisplayMenu()
        {
            
            while (true)
            {
                Console.WriteLine("==========================Welcome to Movie Management App=========================");
                Console.WriteLine($"What do u want to do?\n1"+
                    $"Add a movie\n" +
                    $"2.Display all movie\n"+
                    $"3.Find moive by Id\n"+
                    $"4.Remove a movie\n" +
                    $"5.Clear all movies\n"+
                    $"6.Exit\n"+
                    $"enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);

            }


        }

        static void DoTask(int choice)
        {
            
            switch (choice)
            {
                case 1:
                    AddNewMovie();
                    break;
                case 2:
                    if (movies.Count == 0)
                        Console.WriteLine("Movie list is empty");
                    else
                        movies.ForEach(movie => Console.WriteLine(movie));
                    break;
                case 3:
                    Movie findMovie = FindMovieById();
                    if (findMovie != null)
                        Console.WriteLine(findMovie);
                    else
                        Console.WriteLine("Movie not found");
                    break;
                case 4:
                    RemoveMovie();
                    break;
                case 5:
                    if (movies.Count == 0)
                        Console.WriteLine("Movie list is already empty! Nothing to clear");
                    else
                        movies.Clear();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input");
                    break;


            }
        }

        static void RemoveMovie()
        {
            Movie findMovie = FindMovieById();
            if (findMovie == null)
                Console.WriteLine("Movie not found");
            else
            {
                movies.Remove(findMovie);
                Console.WriteLine("Movie deleted successfully");

            }
        }

        static Movie FindMovieById()
        {
            Movie findMovie = null;
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            return findMovie;
        }

        static void AddNewMovie()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Genre:");
            string genre = (Console.ReadLine());
            Console.WriteLine("Enter year of release:");
            int year= Convert.ToInt32(Console.ReadLine());
            Movie newMovie = Movie.AddMovie(id, name, genre,year);
            movies.Add(newMovie);
            Console.WriteLine("New Movie added successfully");
        }
    }
}

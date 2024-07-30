using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Repositary;

namespace MovieManagment.VeiwControllers
{
    public class MovieStore
    {
        public static void DisplayMenu()
        {

            MovieManager.ManageMovie();
            while (true)
            {
                Console.WriteLine("==========================Welcome to Movie Management App=========================");
                Console.WriteLine($"What do u want to do?\n1" +
                    $"Add a movie\n" +
                    $"2.Display all movie\n" +
                    $"3.Find moive by Id\n" +
                    $"4.Remove a movie\n" +
                    $"5.Clear all movies\n" +
                    $"6.Exit\n" +
                    $"enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }

        static void DoTask(int choice)
        {

            switch (choice)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Find();
                    
                    break;
                case 4:
                    Remove();
                    break;
                case 5:
                    MovieManager.ClearAllMovies();
                    Console.WriteLine("All movies cleared");
                    break;
                case 6:
                    MovieManager.ExitAccount();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input");
                    break;


            }
        }

        static void Add()
        {
            int id = 0;
            Console.WriteLine("Enter Id:");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Genre:");
            string genre = (Console.ReadLine());
            Console.WriteLine("Enter year of release:");
            int year = Convert.ToInt32(Console.ReadLine());
            MovieManager.AddNewMovie(id, name, genre, year);
            Console.WriteLine("Movie added successfully");


        }

        static void Display()
        {
            var movies = MovieManager.DisplayMovie();
            movies.ForEach(movie => Console.WriteLine(movie));
            

        }

        static void Find()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var movie = MovieManager.FindMovieById(id);
            Console.WriteLine(movie);
        }

        static void Remove()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieManager.RemoveMovie(id); 
            Console.WriteLine("Movie deleted successfully");


        }

    }
}

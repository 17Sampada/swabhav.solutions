using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.models;
using MovieLibrary.Services;

namespace MovieLibrary.Repositary
{
    public class MovieManager
    {
        public static List<Movie> movies = new List<Movie>();

        public static void ManageMovie()
        {
            movies = DataSerializer.DeserializeMovies();
        }

        public static void AddNewMovie(int id, string name, string genre, int year)
        {
             
            if (movies.Count == 5)
            {
                throw new MovieCapcityFullException("Movie store is at its capacity!! Can't add new movies");

            }
            Movie newMovie=Movie.AddMovie(id, name, genre, year);
            movies.Add(newMovie);
            
        }

        public static List<Movie> DisplayMovie()
        {
            if (movies.Count == 0)
                throw new MovieListEmptyException("Movie list is empty");
            else
                return movies;
        }

        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            if (findMovie != null)
                return(findMovie);
            else
                throw new MovieNotFoundException("Movie not found");
            
        }

        public static void RemoveMovie(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie not found");
            else
            {
                movies.Remove(findMovie);
                
            }
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieListEmptyException("Movie list is already empty! Nothing to clear");
            else
                movies.Clear();
        }

        public static void ExitAccount()
        {
            DataSerializer.SerializeMovies(movies);
        }
    }
}

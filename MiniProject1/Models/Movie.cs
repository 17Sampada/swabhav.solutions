using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public int YearOfRelease {  get; set; }

        public Movie() { }

        public Movie(int id,string name, string genre,int year)
        {
            Id = id;
            Name = name;
            Genre = genre;
            YearOfRelease = year;
            
        }

        public static Movie AddMovie(int id, string name, string genre, int year) 
        { 
            return new Movie(id, name, genre, year);
        }

        public override string ToString()
        {
            return $"=======================Movie ID: {Id}============================\n" +
                $"Movie Name: {Name}\n" +
                $"Genre:{Genre}\n"+
                $"Year of release: {YearOfRelease}";
        }





    }
}

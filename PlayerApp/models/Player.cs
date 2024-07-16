using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerApp.models
{
    internal class Player
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

       static int DEFAULT_AGE=18;

        public Player(int id, string name) {
            Id = id;
            Name = name;
            Age = DEFAULT_AGE;
            


        }

        public Player (int id, string name, int age):this (id, name) 
        {
            Age = age;
            
        }

        public static Player WhoIsElder(Player[] players)
        {
            Player eldest = players[0];
            foreach (Player player in players)
            {
                if (player.Age > eldest.Age)
                {
                    eldest = player;
                }
            }
            return eldest;
        }

        public override string ToString()
        {
            return $"Player Id: {Id}\n" +
                $"Name: {Name}\n"+
                $"Age: {Age}";
        }






    }
}

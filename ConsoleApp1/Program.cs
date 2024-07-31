using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                PlayGame();
                playAgain = AskToPlayAgain();
            }
        }
        static void PlayGame()
        {
            Random random = new Random();
            int numberToGuess = random.Next(1, 11);
            int attempts = 0, maxTries = 3;

            Console.WriteLine("I have generated a number between 1 and 10. You have 3 chances to guess it!");

            while (attempts < maxTries)
            {
                Console.Write("Enter your guess: ");
                if (!int.TryParse(Console.ReadLine(), out int userGuess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                attempts++;

                if (userGuess < numberToGuess)
                {
                    Console.WriteLine("Sorry, too low.");
                }
                else if (userGuess > numberToGuess)
                {
                    Console.WriteLine("Sorry, too high.");
                }
                else
                {
                    Console.WriteLine($"Congrats! You won! You guessed the number in {attempts} tries.");
                    return;
                }
            }

            Console.WriteLine($"Sorry, you've used all {maxTries} tries. The number was {numberToGuess}.");
        }

        static bool AskToPlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play again? (y/n): ");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter 'y' or 'n'.");
                }
            }
        }
    }
}

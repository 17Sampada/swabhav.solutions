using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigADice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool playAgain = true;
            Console.WriteLine("Let's Play PIG!\n");
            Console.WriteLine("See how many turns it takes you to get to 20.");
            Console.WriteLine("Turn ends when you hold or roll a 1.");
            Console.WriteLine("If you roll a 1, you lose all points for the turn.");
            Console.WriteLine("If you hold, you save all points for the turn.\n");


            while (playAgain)
            {
                PlayGame();
                playAgain = AskToPlayAgain();
            }
        }

        static void PlayGame()
        {
            Random random = new Random();
            Console.WriteLine("Welcome to Pig Game");
            int totalScore = 0;
            int turn = 1;
            while (totalScore < 20)
            {
                Console.WriteLine($"TURN {turn}:\n");
                int turnScore = 0;
                bool turnOver = false;

                while (!turnOver)
                {
                    Console.WriteLine("Enter 'r' to roll again, 'h' to hold.");
                    char userChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (userChoice == 'r')
                    {
                        int diceNumber = random.Next(1, 7);
                        Console.WriteLine($"You rolled: {diceNumber}");

                        if (diceNumber == 1)
                        {
                            Console.WriteLine("Turn over. No Score\n");
                            turnOver = true;
                        }
                        else
                        {
                            turnScore += diceNumber;
                            Console.WriteLine($"Your turn score is {turnScore} and your total score is {totalScore}");
                            Console.WriteLine($"If you hold, you will have {totalScore + turnScore} points.");
                        }
                    }
                    else if (userChoice == 'h')
                    {
                        totalScore += turnScore;
                        Console.WriteLine($"Your turn score is {turnScore} and your total score is {totalScore}\n");
                        turnOver = true;
                    }
                }

                turn++;
            }
            Console.WriteLine($"You Win! You finished in {turn-1} turns!");
            Console.WriteLine("Game over!");

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

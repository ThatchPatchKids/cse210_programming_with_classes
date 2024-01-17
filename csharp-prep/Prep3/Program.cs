using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string response;
        do 
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1,100);
            bool found = false;
            int guessNumber;
            int guesses = 0;
            while (!found)
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guessNumber = int.Parse(guess);
                guesses += 1;

                if (guessNumber == magicNumber)
                {
                    found = true;
                }
                else if (guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }
            }
            Console.WriteLine($"Congratulations! You guessed the number {magicNumber}!");
            Console.WriteLine($"You found it in {guesses} guesses.");
            Console.Write("Do you want to play again? ");
            response = Console.ReadLine();
            
        } while (response == "yes");


    }
}
using System;
using System.Linq;

namespace RockPaperScissors
{
    class Game
    {
        static void Main(string[] args)
        {
            // Specify how many rounds the player has to win to complete the game
            int winAmount = 10;
            if (args.Length > 0) winAmount = int.Parse(args[0]);

            // Create an array to represent the weapons of choice
            string[] Weapons = { "Rock", "Paper", "Scissors" };

            // Create an array to store the scores in
            int[] Scores = { 0, 0 };

            Console.Write($"\nWelcome to the best 'Rock, Paper, Scissors' game made in .NET!\nYou will need to beat the computer {winAmount} times before winning the game.\n\nTo begin, press [ RETURN ]");
            Console.ReadLine();

            int rounds = 0;
            while (Scores[0] < winAmount && Scores[1] < winAmount)
            {
                // Announce the Round #
                rounds++;
                Console.WriteLine($"\n===== [ ROUND {rounds} ] =====");

                // Generate choice variables
                Console.Write("\nSelect your choice.\n\n  1. Rock\n  2. Paper\n  3. Scissors.\n\n > ");
                int computerChoice = CPUChoice();

                // Check if input is valid
                bool validInput = int.TryParse(Console.ReadLine(), out int userChoice);

                // If input is invalid or out of bounds
                if (!validInput || (userChoice < 1 || userChoice > 3))
                {
                    // Subtract one from the 'rounds' variable and continue the loop
                    rounds--;
                    continue;
                }

                // Set 'userChoice' to be 'userChoice - 1' so that it can be
                // computed and compared to the CPU's choice
                userChoice -= 1;

                // Announce choices picked
                Console.WriteLine($"\nYou choose {Weapons[userChoice]}. The Computer chooses {Weapons[computerChoice]}.");

                // Evaluate the winner
                int winner = EvaluateBattle(userChoice, computerChoice);

                // Add score to the winner if no draw has occured
                if (winner != 2) Scores[winner]++;

                // Output who wins
                if (winner == 0) Console.Write("You win this round.");
                else if (winner == 1) Console.Write("The Computer wins this round.");
                else Console.Write("It's a draw! No one wins this round.");

                // Announce the current standings
                Console.WriteLine($" The Score stands {Scores[0]} (PLAYER) to {Scores[1]} (CPU).");
            }

            // We're outside of the while loop now, meaning someone has won

            // Evaluate who wins and outpute according to that
            if (Scores[0] >= winAmount) Console.WriteLine($"\nYou win with a score of {Scores[0]}! You beat the Computer by {Scores[0] - Scores[1]} points.");
            else Console.WriteLine($"\nYou Lose with a score of {Scores[0]}! The Computer beat you by {Scores[1] - Scores[0]} points.");

            // Play Again feature - no need for iteration
            Console.Write("\nDo you want to play again? Type YES or NO.\n > ");
            if (Console.ReadLine().ToLower().Contains("y")) Main(args);
            else
            {
                Console.WriteLine("\nPress [ RETURN ] when you are ready to exit the program.");
                Console.ReadLine();
            }
        }

        // Generate and return random number between 0 and 3
        static int CPUChoice()
        {
            Random Choice = new Random();
            return Choice.Next(3);
        }

        // Returns 0 if Human wins
        // Returns 1 if CPU wins
        // Returns 2 if noone wins
        static int EvaluateBattle(int userInput, int CPUInput)
        {
            if (userInput == CPUInput) return 2;
            if (userInput == 0 && CPUInput == 1) return 1;
            if (userInput == 1 && CPUInput == 2) return 1;
            if (userInput == 2 && CPUInput == 0) return 1;
            return 0;
        }
    }
}

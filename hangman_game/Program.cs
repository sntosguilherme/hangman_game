using System.ComponentModel;
using System.Diagnostics;

namespace hangman_game
{
    internal class Program
    {
        static void Main(string[] args)
        {

        //variables and lists

            bool victory = false;
            string word = "";
            int maxLives = 6;
            int currentLives = maxLives;
            List<char> guessedLetters = new List<char>();

        //start of the program

            Console.WriteLine("Welcome to the hangman game!");
            RandomWord();

            while (!victory && currentLives > 0)
            {
                Console.WriteLine(HangMan());
                PrintWord();
                
                Console.WriteLine("\nPlease, guess a letter!");

                string stringGuess = Console.ReadLine().ToLower();
                char guess = Convert.ToChar(stringGuess[0]);

                

                if (word.Contains(guess) && !guessedLetters.Contains(guess))
                {
                    Console.WriteLine("Correct!");
                    guessedLetters.Add(guess);
                }
                else 
                { 
                    Console.WriteLine("Wrong guess!");
                    currentLives--;
                }

                bool wordComplete = true;

                foreach (char c in word)
                {
                    if (!guessedLetters.Contains(c)) { wordComplete = false; }
                }

                victory = wordComplete;
            }

            if (victory)
            {
                Console.WriteLine("Congratulations! you win!");
            }
            else
            {
                Console.WriteLine("\nSorry, You lost...");
                Console.WriteLine(HangMan());
            }
            
            // end of the program.
            
            //functions.
   
            void RandomWord()
            {
                string[] wordsToGuess = new string[] 
                {
                    "apple",
                    "banana",
                    "cherry",
                    "dog",
                    "elephant",
                    "forest",
                    "giraffe",
                    "horizon",
                    "island",
                    "jungle"
                }; 

                Random rand1 = new Random();
                int wordIndex = rand1.Next(wordsToGuess.Length);
                
                word = wordsToGuess[wordIndex];
            }

            void PrintWord()
            {
                Console.WriteLine();
                Console.Write("");
                foreach (char c in word)
                {
                    if (guessedLetters.Contains(c))
                    {
                        Console.Write(c);
                    }
                    else 
                    { 
                        Console.Write("_"); 
                    }
                }
            }

            string HangMan()
            {
                switch (currentLives)
                {
                    case 6: 
                        return """
                           ______
                           |/   |
                           |    
                           |   
                           |   
                           """;
                    case 5:
                        return """
                           ______
                           |/   |
                           |    O
                           |   
                           |   
                           """;

                    case 4:
                        return """
                           ______
                           |/   |
                           |    O
                           |    |
                           |   
                           """;
                    case 3:
                        return """
                           ______
                           |/   |
                           |    O
                           |   /|
                           |   
                           """;
                    case 2:
                        return """
                           ______
                           |/   |
                           |    O
                           |   /|\
                           |   
                           """;
                    case 1:
                        return """
                           ______
                           |/   |
                           |    O
                           |   /|\
                           |   / 
                           """;
                    default:
                        return """
                           ______
                           |/   |
                           |    O
                           |   /|\
                           |   / \
                           """;
                }

            }
        }
    }
}

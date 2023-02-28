//////////////////////////
/////////WARNING!/////////
//////////////////////////
//THIS CODE WILL NOT WORK IF YOU DON'T HAVE A WORDS FILE WITH AT LEAST 1 WORD IN IT!
using System;
using System.IO;     //Used to access the words file
using System.Linq;   //Used to count letters in words

namespace Wordle
{
    public class Program
    {
        public static void Main()
        {
            Random R = new Random();
            string path = "words.txt";  //Path for a file in which your words are written
            int chances = 6;            //Amount of guesses uses get

            //Read the file and choose a random word
            string[] words = File.ReadAllLines(path).Select(x => x.ToLowerInvariant()).ToArray();
            string word = words[R.Next(words.Length)].ToLower();

            string guess;

            //This is where the guesses happen
            for(int i = 0;i < chances;i++) {
                while(true)
                {
                    try
                    {
                        //Makes sure the guess is a word included in the file
                        guess = Console.ReadLine().ToLower();
                        if(!Array.Exists(words, element => element == guess)) /**/throw new Exception();/*Replace this to change what happens when the guess is not a word*/
                        break;
                    }
                    catch(Exception) {}
                }
                //Analyzes the guess and writes the results
                WriteResults(CheckLetters(word, guess), guess);

                //Adds a new line to separate the guesses
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine("You lose!");
            Console.WriteLine($"The word was {word}");
        }
        
        public enum LetterStatus
        {
            Wrong,          // "This letter is not in the word."
            WrongPos,       // "This letter is in the word, but not in this position."
            Correct         // "This letter is in the word in this position."
        }

        public static LetterStatus[] CheckLetters(string word, string guess)
        {
            var result = new LetterStatus[5];

            for (int i = 0; i < guess.Length; i++)
            {
                //If the letters are the same, mark it as CORRECT
                if (word[i] == guess[i])
                {
                    result[i] = LetterStatus.Correct;
                }

                //Otherwise, check if the letter is in the word
                else if (word.Contains(guess[i]))
                {
                    //If there are more than 1 occurances of the same letter
                    if(guess.Count(f => (f == guess[i])) > 1) {

                        //If the guess has more of the letter than the word
                        if(word.Count(f => (f == guess[i])) < guess.Count(f => (f == guess[i]))) {

                            //Check if it is the first occurance, we can mark only one of them as WRONG POSITION
                            if(guess.IndexOf(guess[i]) < i) continue;

                            //Otherwise, mark it as WRONG POSITION
                            else{result[i] = LetterStatus.WrongPos;}
                        }
                        
                        //Otherwise, if they have the same amount, mark both as WRONG POSITION
                        else if(word.Count(f => (f == guess[i])) == guess.Count(f => (f == guess[i]))) {
                            result[i] = LetterStatus.WrongPos;
                        }

                        //Throw a new exception, I have no plan B for this...
                        else{throw new Exception();}
                    }

                    //Otherwise, mark it as WRONG POSITION
                    else{result[i] = LetterStatus.WrongPos;}
                }

                //Otherwise, mark it as WRONG
                else
                {
                    result[i] = LetterStatus.Wrong;
                }
            }

            //Send the result back
            return result;
        }

        public static void WriteResults(LetterStatus[] result, string guess)
        {
            //This is used to keep track of which letter we are at
            int x = 0;

            //Writes each letters with their appropriate color!
            //        Correct = Green
            // Wrong Position = Yellow
            //          Wrong = Dark Gray
            foreach(LetterStatus i in result) {
                try
                {
                    if(i == LetterStatus.Correct) {                     //Correct case
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(i == LetterStatus.WrongPos) {               //Wrong position case
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else{                                               //Wrong case
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    //Writes the letter
                    Console.Write(guess.ToCharArray()[x]);
                    
                    //We increase the number to change to the next letter
                    x++;
                }
                catch(IndexOutOfRangeException) {}
            }

            //Resets foreground (text) color
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
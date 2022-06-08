using System;
using System.Threading;

namespace RPS
{
    class Program
    {
        static void Main()
        {
            Random R = new Random();    //Declaring this from the beginning so we can pick random moves later on for the PC!
            int win = 0;                //Integer to keep track of wins
            int lose = 0;               //Integer to keep track of loses
            int draw = 0;               //Integer to keep track of draws
            int aiMoveN;                //Integer to keep track of PC's current move
            string aiMove;              //String to convert numerical representation of the move to a string
            string input;               //String to keep track of user's current move
            
            while(true)                                                                         //Infinite loop to keep the game going until the console is closed
            {
                while(true)                                                                     //Another loop to keep asking for an input until we get one we can accept
                {
                    Console.Clear();
                    Console.WriteLine("Make a move!\n\nR (Rock) - P (Paper) - S (Scissors)");
                    input = Console.ReadKey().KeyChar.ToString().ToLower();                     //We get the key user presses, convert it to a character, then to a string, and then we turn it into it's lowercase form to avoid troubles.

                    if(input == "r" || input == "p" || input == "s")                            //We check if the input was 'R', 'P' or 'S'
                    {
                        if(input == "r")       {input = "Rock";}
                        else if(input == "p")  {input = "Paper";}                               //Swapping the letter with the word
                        else                   {input = "Scissors";}
                        break;
                    }
                }

                Console.Clear();
                aiMoveN = R.Next(3);

                if(aiMoveN == 0)       {aiMove = "Rock";}
                else if(aiMoveN == 1)  {aiMove = "Paper";}                                      //Doing the same for user's move
                else                   {aiMove = "Scissors";}

                if(input == aiMove)                                                             //Draw case
                {
                    Console.WriteLine("Draw!\n\n\nYour move: {0}\nMy move: {0}", input);
                    draw++;
                }

                                                                                                //User's lose case
                else if(input == "Rock" && aiMove == "Paper" || input == "Paper" && aiMove == "Scissors" || input == "Scissors" && aiMove == "Rock")
                {
                    Console.WriteLine("I win!\n\n\nYour move: {0}\nMy move: {1}", input, aiMove);
                    lose++;
                }

                else                                                                            //User's win case
                {
                    Console.WriteLine("You win!\n\n\nYour move: {0}\nMy move: {1}", input, aiMove);
                    win++;
                }

                Console.WriteLine("\nTotal games: {0}\nWins: {1}", win + lose + draw, win);
                Thread.Sleep(2500);                                                              //Small delay
            }
        }
    }
}

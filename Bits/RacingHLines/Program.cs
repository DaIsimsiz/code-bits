using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace RacingHLines
{
    class Racer
    {
        public int progress;

        public Racer()
        {
            this.progress = 0;
        }
    }

    class Program
    {
        static void Main()
        {
            Random R = new Random();
            List<Racer> Racers = new List<Racer>();                     //The list we will put the racers in!
            Console.WriteLine("How many racers should there be?");
            int input;                                                  //Input variable is declared in here!
            while(true)                                                 //We loop this because we want to keep asking this until we find an answer we like!
            {                                                           //We read the console input here,
                if(int.TryParse(Console.ReadLine(), out input)) break;  //and check if it is a number!
            }
            Console.Clear();                                            //We tidy up the console by deleting all messages.
            for(int i = 0;i<(int)input;i++)                             //Here, we start a loop that will create all the Racers requested!
            {
                Racers.Add(new Racer());                                //We add each racer to the list 1 by 1...
            }
            Console.WriteLine("At which number should racers win?");
            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out input)) break;  //We already went over this...
            }
            Console.Clear();                                            //Clearing the console again...
            foreach(Racer Racer in Racers)                              //Repeating this code for each racer in the list!
            {
                DrawRacer(Racer);                                       //This is a custom method we made to make things easier!
            }                                                           //Scroll down to see the explanation, it's short!
            while(true)
            {
                Thread.Sleep(500);                                      //Adding a 500ms delay to slow it down.
                Console.Clear();                                        //Clearing the console yet again...
                foreach(Racer Racer in Racers)
                {
                    Racer.progress += R.Next(2);                        //Randomly adding 1 or 0 to the racer's progress!
                    DrawRacer(Racer);                                   //We already went over this...
                }
                if(RaceEnded(Racers, input)) break;                     //Ending the loop if a racer has won the game...
            }                                                           //...scroll down for more info!
            Console.ReadKey();                                          //Waiting for a key input to let the user read the screen!
        }

        static void DrawRacer(Racer Racer)
        {
            for(int i = 0;i < Racer.progress;i++)                       //We read the progress property of the racer...
            {
                Console.Write("-");                                     //... and put the equivalent amount of dashes for the trail!
            }
            Console.Write("> {0}\n", Racer.progress);                   //Then we draw the head, which will be a '>', we then...
        }                                                               //...write their progress to make it easier to read!

        static bool RaceEnded(List<Racer> Racers, int goal)
        {
            foreach(Racer Racer in Racers)
            {
                if(Racer.progress == goal) return true;                 //We check if the racer ended the race to decide if...
            }                                                           //...we should conclude the race!
            return false;
        }
    }
}

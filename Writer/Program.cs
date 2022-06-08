using System;
using System.Threading;

namespace Writer
{
    class Program
    {
        static void Main()
        {
            char[] input;
            while(true)
            {
                Console.WriteLine("Waiting for input...");
                input = Console.ReadLine().ToCharArray();   //Converting console input into a list of characters
                Console.Clear();
                foreach(char i in input)
                {
                    Console.Write(i);                       //Writing the characters in order 1 by 1
                    Thread.Sleep(125);                      //And waiting 125ms between each character
                }
                Console.WriteLine("\n");
            }
        }
    }
}

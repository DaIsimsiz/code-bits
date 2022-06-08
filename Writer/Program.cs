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
                input = Console.ReadLine().ToCharArray();
                Console.Clear();
                foreach(char i in input)
                {
                    Console.Write(i);
                    Thread.Sleep(125);
                }
                Console.WriteLine("\n");
            }
        }
    }
}

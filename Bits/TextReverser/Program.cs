using System;

namespace TextReverser
{
    class Program
    {
        static void Main()
        {
            char[] input;
            while(true)
            {
                Console.WriteLine("Waiting for input...");
                input = Console.ReadLine().ToCharArray();           //Split input into characters
                Console.Clear();
                for(int i = 0;i < input.Length;i++)
                {
                    Console.Write(input[input.Length - (i + 1)]);   //We write the characters from back to front
                }
                Console.WriteLine("\n");
            }
        }
    }
}

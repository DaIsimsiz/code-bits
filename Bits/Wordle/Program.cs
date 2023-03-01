//Post rewrite message
//
//Basically the same code, just a bit more clean.

public class Program
{
    public enum LetterStatus
    {
        Wrong,
        WrongPos,
        Correct
    }

    public static void Main()
    {
        string path = "words.txt";
        int attempts = 6;

        string[] words = File.ReadAllLines(path).Select(x => x.ToLower()).ToArray();
        string word = words[new Random().Next(words.Length)];

        string input = "";

        for(int i = 0;i < attempts;i++)
        {
            //Validate guess
            while(true)
            {
                try
                {
                    #pragma warning disable //shut up
                    input = Console.ReadLine().ToLower();
                    #pragma warning restore
                    if(!Array.Exists(words, x => x == input)) throw new Exception();
                    break;
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            DumpResults(Compare(word,input), input);
            Console.WriteLine();

            if(input == word) {
                Console.WriteLine("You've guessed the word!");
                break;
            }
        }
        if(input != word) Console.WriteLine("The word was {0}", word);
        Console.ReadKey();
    }


    public static LetterStatus[] Compare(string word, string input)
    {
        LetterStatus[] result = new LetterStatus[word.ToCharArray().Length];

            for(int i = 0; i < input.Length; i++)
            {
                if (word[i] == input[i]) result[i] = LetterStatus.Correct;

                else if (word.Contains(input[i]))
                {
                    if(input.Count(f => (f == input[i])) > 1 && word.Count(f => (f == input[i])) < input.Count(f => (f == input[i]))) {

                        if(checkValidity(word, input, i)) result[i] = LetterStatus.WrongPos;

                        else result[i] = LetterStatus.Wrong;
                    }

                    else{result[i] = LetterStatus.WrongPos;}
                }

                else result[i] = LetterStatus.Wrong;
            }

            return result;
    }

    public static bool checkValidity(string word, string input, int i)
    {
        //I encourage you to try to reverse-engineer the purpose of this
        int max = word.Count(f => (f == input[i]));
        int found = 0;

        for(int x = 0;x < i;x++)
        {
            if(input[x] == input[i]) found++;
            if(found == max) return false;
        }
        return true;
    }

    public static void DumpResults(LetterStatus[] results, string input)
    {
        for(int i = 0;i < results.Length;i++)
        {
            try
            {
                if(results[i] == LetterStatus.Correct) Console.ForegroundColor = ConsoleColor.Green;
                else if(results[i] == LetterStatus.WrongPos) Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write(input.ToCharArray()[i]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                //Just in case
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
//Post rewrite message
//
//The previous code was over-complicated, now it's much cleaner.

class Program
{

    static void Main()
    {
        int win, lose, draw;
        win = lose = draw = 0;

        int pc;
        int player;

        string input;
        string[] moves = {"r","p","s"};

        string[] rps = {"Rock", "Paper", "Scissors"};
            
        while(true)
        {
            while(true) {
                Console.Clear();
                Console.WriteLine("Rock = R\nPaper = P\nScissors = S\n\nPick one!");

                #pragma warning disable //silences the warning in here mentioning that "Console.ReadLine()" could be null
                input = Console.ReadLine().ToLower();
                #pragma warning restore

                if(moves.Contains(input)) break;
            }

            if(input == "r") player = 0;
            else if(input == "p") player = 1;
            else player = 2;
                
            pc = new Random().Next(3);

            //    rock = 0
            //   paper = 1
            //scissors = 2

            if(player == pc) {
                draw++;
                Console.WriteLine("\nBoth players chose {0}, it's a draw!\nWins: {1} - Losses: {2} - Draws: {3}\nTotal games: {4}", rps[player], win, lose, draw, win+lose+draw);
            }
            else if(player < pc || player == pc + 2) {
                win++;
                Console.WriteLine("\nYou: {0}\nPC: {1}\nYou've won!\nWins: {2} - Losses: {3} - Draws: {4}\nTotal games: {5}", rps[player], rps[pc], win, lose, draw, win+lose+draw);
            }
            else{
                lose++;
                Console.WriteLine("\nYou: {0}\nPC: {1}\nYou've lost.\nWins: {2} - Losses: {3} - Draws: {4}\nTotal games: {5}", rps[player], rps[pc], win, lose, draw, win+lose+draw);
            }
            Thread.Sleep(2500);
        }
    }
}

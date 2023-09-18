//Post revision comment
//
//Corrected a misnomer.

//This program is based on Shor's Algorithm, it is related to our present day encryption.
//It allows us to find the 2 prime factors of an integer. This process is very slow on today's computers, but it will be insanely fast on quantum computers.

class Program
{
    static void Main() {
        Console.WriteLine("Enter a semiprime number (Multiplication of 2 prime numbers).");
        int n;
        while(true){
            if(!int.TryParse(Console.ReadLine(), out n)) Console.WriteLine("Please enter a valid number."); else break;
        }
        double result;
        double divisor;
        while(true){
            result = Guess(n);
            if(result != -1) {
                divisor = Shor(result, n);
                if(divisor == 1) continue;
                else{break;}
            }
        }
        Console.WriteLine(divisor + " and " + n/divisor + " are the divisors of your semiprime number.");
    }

//The 2 functions below are direct implementation of Shor's algorithm. It's split in 2 to make it simpler to code and read.

    static double Guess(int input) {
        
        int g = new Random().Next(input);

        int i = 1;
        while(true) {
            if(Math.Pow(g,i)%input == 1 && i%2 != 0) {return Math.Pow(g,i/2)+1;}
            i++;
        }
    }

    static double Shor(double result, int input) {
        double[] x = {result, input};
        double temp;
        while(true){
            Array.Sort(x);
            temp = x[1] % x[0];
            if(temp == 0) {return x[0];}
            else{
                if(temp > x[0]) x[0] = temp;
                else{x[1] = temp;}
            }
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random(); //creating an instance of the Random class,
        int magicNum_int = randomGenerator.Next(1, 101);// using it to get number >= 1 but less than 101
       
        Console.WriteLine("What is the Magic Number?"); //ask for number
        //string magicNum_string = Console.ReadLine();//get number from user, but remember everthing from this function is returned a string
        //int magicNum_int = int.Parse(magicNum_string);//parsing the string to an int so we can make a comparison
        Console.Write("What is your guess?");//ask for a guess.  Using the Console.Write will NOT place a return after
        string guess_string = Console.ReadLine();//reading the input as string
        int guess_int = int.Parse(guess_string);//parsing the string to an int
        int guesses = 1;//variable to keep number of guesses, set = to one in case it is guessed on 1st try

        while (guess_int != magicNum_int)
        {
            if (guess_int > magicNum_int)
            {
                Console.WriteLine("Lower");
                Console.Write("What is your guess? ");
                guess_string = Console.ReadLine();
                guess_int = int.Parse(guess_string);
            }
            else 
            {
                Console.WriteLine("Higher");
                Console.Write("What is your guess? ");
                guess_string = Console.ReadLine();
                guess_int = int.Parse(guess_string);


            }
            
            guesses = guesses ++;//increment guesses by 1 each time runs full loop
        }
           

        Console.WriteLine("You guessed it!");
        Console.Write($"You took {guesses} to guess the correct number");


       
    }
}
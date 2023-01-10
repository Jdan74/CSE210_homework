using System;

class Program
{
    static void Main(string[] args)
    {
        
    static void DisplayWelcome ()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    } 
    
    static int PromptUserNumber()
    {
        Console.Write("Please enter favorite number: ");
        string userResponse = Console.ReadLine();
        int favNum = int.Parse(userResponse);
        return favNum;
    }
    static int SquareNumber(int favNum)
    {
        int square = favNum * favNum;
        return square;
    }
    static void DisplayResult(string name, int square)
    {
        Console.Write($"{name}, the square of your number is {square} ");

    }

    DisplayWelcome ();  //Welcome to the program!
        string name = PromptUserName(); //Please enter your name: Brother Burton
        int favNum = PromptUserNumber();//Please enter your favorite number: 42
        int square = SquareNumber(favNum);//sqare the number
        DisplayResult(name, square);


    }

    private static void PromptUserName()
    {
        throw new NotImplementedException();
    }
}
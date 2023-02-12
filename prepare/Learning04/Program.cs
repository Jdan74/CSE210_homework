using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment Assignment1 = new Assignment("Samual Bennett", "Multiplication");
        MathAssignment Math1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19" );
        WritingAssignment Writing1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        Console.WriteLine(Assignment1.GetSummary());
        Console.WriteLine();
        Console.WriteLine(Math1.GetSummary());
        Console.WriteLine(Math1.GetHomeworkList());
        Console.WriteLine();
        Console.WriteLine(Writing1.GetSummary());
        Console.WriteLine(Writing1.GetWritingInformation());

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";
        
        Console.WriteLine("What is your grade percentage?");
        string grade_string = Console.ReadLine();
        int grade_int = int.Parse(grade_string);

        if (grade_int >= 90)
        {
             letter = "A";
             //Console.WriteLine("Your grade is an A");
        }  
        else if (grade_int >= 80)
        {
            letter = "B";
            //Console.WriteLine("Your grade is a B");
        }  
        else if (grade_int >= 70)
        {
            letter = "C";
            //Console.WriteLine("Your grade is a C");
        }  
        else if (grade_int >= 60)
        {
            letter = "D";
            //Console.WriteLine("Your grade is a D");
        }
        else 
        {
            letter = "F";
            //Console.WriteLine("Your grade is an F");
        }  

        Console.WriteLine($"Your Grade is: {letter}");

        if (grade_int >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else 
        {
            Console.WriteLine("Sorry, you failed the class but you can always try again!");
        }





    }
}
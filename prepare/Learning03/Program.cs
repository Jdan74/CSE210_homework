using System;

class Program
{
    static void Main(string[] args)
    {
        
        Fraction Fraction1 = new Fraction();//calling the generic constructor
        
        Fraction1.SetTop(1);//using the setter on this instance to set top value to 3
        Fraction1.SetBottom(1);//using the setter on this instance to set bottom value to 4
              
        Fraction Fraction2 = new Fraction(5);//calling the constructor that accepts one whole number and set it to the top number and sets 1 as the bottom

        Fraction Fraction3 = new Fraction(3,4);//calling the construction that accepts a 2 numbers, a top and then bottom

        Fraction Fraction4 = new Fraction(1,3);//calling the construction that accepts a 2 numbers, a top and then bottom

        
        
        
        Console.WriteLine("displaying Fraction1");
        Fraction1.GetFractionString();//below we are calling both of our methods for each of these instances
        Fraction1.GetDecimalValue();
        
        Console.WriteLine("displaying Fraction2");
        Fraction2.GetFractionString();
        Fraction2.GetDecimalValue();
        
        Console.WriteLine("displaying Fraction3");
        Fraction3.GetFractionString();
        Fraction3.GetDecimalValue();
        
        Console.WriteLine("displaying Fraction4");
        Fraction4.GetFractionString();
        Fraction4.GetDecimalValue();




    }
}
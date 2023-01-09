using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
              
        List<int> numbers = new List<int>();//creating an object of class List
        
        Console.Write("Enter a number: ");
        string number_string = Console.ReadLine();
        int number_int = int.Parse(number_string);//parse to an int
        
        while (number_int !=0)//while loop to run until 0 is entered as the number
        {
            
            numbers.Add(number_int);//adding the number to the list
            Console.Write("Enter a number: ");
            number_string = Console.ReadLine();
            number_int = int.Parse(number_string);//parse to an int


        }
        
        int sum_numbers = numbers.Sum(); //using the .sum method on the list
        double ave_numbers = numbers.Average();//using the .average method on the list
        int max_numbers = numbers.Max();//usig the .Max method on the list
        int minPosNum = 999999999;//setting a max number to start the loop
        foreach (int number in numbers)// iterating through the loop
        {
            if (number> 0 && number<= minPosNum)//if statment to check if greater than 0 and less than minPosNum
            {
               minPosNum = number;// if statement true will set variable to the new value
            }

        }
        
        Console.WriteLine($"The sum is: {sum_numbers}");
        Console.WriteLine($"The average is: {ave_numbers}");
        Console.WriteLine($"The largest number is: {max_numbers}");
        Console.WriteLine($"The smallest positive number is: {minPosNum}");
       
        numbers.Sort();//sorting the list into ascending order
        Console.WriteLine("The sorted list is: ");
        foreach (int num in numbers)    //iterating through the numbers list to display the sorted list
        {
            Console.WriteLine(num);

        }   
     }
}
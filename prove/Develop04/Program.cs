using System;
// I exceeded the requirements on this by adding function to control for incorrect inputs,
// ability change the breathing interval, and also code to continualy pick a different question on the 
//reflection activity until all were used up or the time ran out.  This was done so as to still return 
//the accurate time used for the exercise.  

class Program
{
    static void Main(string[] args)
    { 
        string choice = "";

        while(choice != "4")
        {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");
        choice = Console.ReadLine();

        if (choice == "1")
        {
            BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by teaching you how to Box breath.  Box Breathing can help reduce heart rate, blood pressure and stress.  It is called box breathing because just like the four equal sides of a box, you will inhale, hold your breath, exhale, then again hold, all for the same interval of time.  4 seconds is a typical interval, but you could go as long as 6 or as short as 2.");
            breathingActivity.RunBreathingActivity(); 
            
        }
        if (choice == "2")
        {
            ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            reflectionActivity.RunReflectionActivity();
            
        }
        if (choice == "3")
        {
            ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. ");
            listingActivity.RunListingActivity();
            
        }
        }
    
        
    }
}
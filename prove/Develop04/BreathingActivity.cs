using System.Diagnostics;
class BreathingActivity : Activity//making this class a child of Activity class
{
//member variables__________________________________________________________________________

private int _breathingTime;//a variable in this class to hold how long each breath in, out, or hold will last
private int _remainingSeconds;// a variable to hold the remaining seconds used in our timer
//Constructors_________________________________________________________________________________

public BreathingActivity(string activityName, string activityInstruction) : base (activityName, activityInstruction)
{
}

//Methods_________________________________________________________________________________________
private void DisplayActivityPrompt()// 
{   
int t = 0;//a variable to hold the time int
string breathTime ="";//a variable to hold the breathTime we'll get from the console
bool isNumber = false;//a bool variable to use in our loop below to check if our input is a number
_remainingSeconds = _seconds;//a variable to hold our original time variable for use with our stopwatch

while (!isNumber)
{
    Console.WriteLine("How many seconds would you like the breathing interval to be? Input a number between 2-6");
    breathTime = Console.ReadLine();
    if(int.TryParse(breathTime, out t))//this will try to parse the string to an int and if it can it will set to variable t and run the first statment, otherwise return false and run the second
    {
        isNumber = true;//setting our bool to true so we can exit the loop
        if (t < 2 || t > 6 )// but first, lets check if the int is within the range we desired
        {
            Console.WriteLine("You have made an unacceptable entry.  Please try again...");//error message
            isNumber = false;//set to false so we stay in the loop
        }
    }
    else
    {
    Console.WriteLine("You have made an unacceptable entry.  Please try again...");//error message and bool stays false
    }

}
   
    GetReady(4);
    Stopwatch s = new Stopwatch();
    s.Start();

    while(s.Elapsed < TimeSpan.FromSeconds(_remainingSeconds))
    
    {
        Console.Write("Inhale...");
        CountDownTimer(t);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Hold your breath...");
        CountDownTimer(t);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Exhale...");
        CountDownTimer(t);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Hold your breath...");
        CountDownTimer(t);
        Console.WriteLine();
        Console.WriteLine();
    }
    Console.WriteLine();
}

public void RunBreathingActivity()
{
    Console.BackgroundColor = ConsoleColor.Blue;//just for fun, let's chage the color
    Console.Clear();
    DisplayActivityStartup();//display the startup messages
    DisplayActivityPrompt();
    EndText();

}



}
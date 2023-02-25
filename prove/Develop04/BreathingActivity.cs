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
    Console.WriteLine("How many seconds would you like your inhale or exhale to last? ");
    string breathTime = Console.ReadLine();
    int t = Int32.Parse(breathTime);//have to parse this to an int
    Console.WriteLine();
    _remainingSeconds = _seconds;
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
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    DisplayActivityStartup();//display the startup messages
    DisplayActivityPrompt();
    EndText();

}



}
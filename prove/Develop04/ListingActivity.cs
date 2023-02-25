
using System.Diagnostics;

class ListingActivity : Activity
{//member variables___________________________________________________________________
    private List<string> _activityPromptList;
    private bool _timesUp = false;//maybe I should make this a parent variable so it can be used by all the classes?
    private int _numEntries;
    private int _remainingSeconds;//maybe I should make this a parent variable so it can be used by all the classes?
    
//Constructors_________________________________________________________________________

    
    public ListingActivity(string activityName, string activityInstruction) : base (activityName, activityInstruction)
    {
        _activityPromptList = new List<string>()//decided to just declare the list in the class rather than when it is instantiated?  Not sure if this is best practice?  probably not if you might want to reuse this class with different questions.
        {
            "When have you felt the Holy Ghost this month?",
            "How have you helped some this month?",
            "What have you learned from the scriptures this week?",
            "How have you tried to be a positive influence on someone this week?"
        };
    }
    
//getters and setters______________________________________________________________________________
//none needed

//Methods______________________________________________________________________

private void DisplayActivityPrompt()//

{
     _remainingSeconds = _seconds;
    GetReady(5);
    Console.WriteLine("List as many responses you can to the following prompt:");
    DisplayRandomPrompt(_activityPromptList);
    Console.Write("You may begin in: ");
    CountDownTimer(3);
    Console.WriteLine();
    ListingActivityAndTimer();
}

private void ListingActivityAndTimer()
{
    Stopwatch s = new Stopwatch();
    s.Start();

    while(s.Elapsed < TimeSpan.FromSeconds(_remainingSeconds))
    {
    Console.Write(">");
    Console.ReadLine();
    _numEntries++;
    }
    s.Stop();
    Console.WriteLine($"You listed {_numEntries} items");
    Console.WriteLine();
} 

public void RunListingActivity()
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.Clear();
    DisplayActivityStartup();
    DisplayActivityPrompt();
    EndText();
}
}











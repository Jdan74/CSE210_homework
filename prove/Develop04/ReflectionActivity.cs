
using System.Diagnostics;

class ReflectionActivity : Activity
{//member variables___________________________________________________________________
    private List<string> _activityPrompts;//a list to hold the prompts
    private List<string> _activityQuestions;//a list to hold the questions about the prompts
    private List<string> _usedactivityQuestions;//a list to hold the indexes I have already used 
    private int _remainingSeconds;//maybe I should make this a parent variable so it can be used by all the classes?
    
//Constructors_________________________________________________________________________

    
    public ReflectionActivity(string activityName, string activityInstruction) : base (activityName, activityInstruction)
    {
        _activityPrompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };
       
       _activityQuestions = new List<string>()
       {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
};
       

    }
    
//getters and setters______________________________________________________________________________
//none

//Methods______________________________________________________________________

private void DisplayActivityPrompt()//random example
{
    _remainingSeconds = _seconds;
    GetReady(5);
    Console.WriteLine("Consider the following prompt:");
    Console.WriteLine();
    DisplayRandomPrompt(_activityPrompts);
    Console.WriteLine("When you have something in mind, press enter to continue.");
    while (Console.ReadKey().Key != ConsoleKey.Enter)//using the console.readkey with an empty whileloop to wait until we press enter
    {
    }
    Console.WriteLine();
    Console.WriteLine("Now ponder on each of the folling questions as they related to this experience.");
    Console.Write("You may begin in: ");
    CountDownTimer(5);
    ReflectionActivityAndTimer();
}

private void ReflectionActivityAndTimer()//almost same function as in my listing activity...could consolidate this and make it one function in main?
{
    Stopwatch s = new Stopwatch();//instantiating a new stopwach 
    int listcount = _activityQuestions.Count;//serring a variable to the index count of the list
    int usedNumCount=0;//variable to hold the counter we'll use to increment every time we send a unique indexed prompt from the list
    int index = ReturnRandomIndexNumberfromList(_activityQuestions);//setting a random number to use from our method we made to get a random number from a list count
    List<int> usedNumbers = new List<int>();//create a new list to hold the used numbers
    Console.Clear();
    s.Start();//starting the stop watch timer
    
        while(s.Elapsed < TimeSpan.FromSeconds(_remainingSeconds) && listcount > usedNumCount)//while loop to compare how much time has elapsed since stop watch started to how much time we started with.  Will stay in loop until the time is passed or the increment count reaches the number of items in our list  
        {
        //DisplayRandomPrompt(_activityQuestions);
            while (usedNumbers.Contains(index))//loop to check if the check to see if the random index number is already in the list of used numbers.
            {
                index = ReturnRandomIndexNumberfromList(_activityQuestions);//set index to a new random number
            } 
        
        Console.WriteLine($"> {_activityQuestions[index]}");//use the unused index to get the questions
        usedNumbers.Add(index);//add our number to the used number list
        Spinner(5);
        usedNumCount++;
        Console.WriteLine();
        }
    
        if (usedNumCount >= listcount)//we'll see if we have reached the end of our list
        {
            Console.WriteLine("You have pondered all available questions before your time was up.");
            s.Stop();//stopping our stopwatch
            TimeSpan elapsed = s.Elapsed; //getting our elapsed time since we didn't reach the time limit
            _seconds = (int)elapsed.TotalSeconds;//setting the elapsed time to our time variable so they get an accurate report on time spent
        }
        
}
public void RunReflectionActivity()
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.Clear();
    DisplayActivityStartup();
    DisplayActivityPrompt();
    EndText();
}
}











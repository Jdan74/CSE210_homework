
class Activity
{//member variables___________________________________________________________________
    protected string _activityName;//setting my variables to protected so they can be accessed by derived classes
    protected string _activityInstruction;
    protected int _seconds;

//Constructors_________________________________________________________________________


    
    public Activity(string activityName, string activityInstruction)//use set this info when we instantiate.
    {
        _activityName = activityName;
        _activityInstruction = activityInstruction;
    }
    
//getters and setters______________________________________________________________________________


//Methods______________________________________________________________________

    public void DisplayActivityStartup()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine();
        Console.WriteLine($"{_activityInstruction}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your Session? ");
        string seconds = Console.ReadLine();
        _seconds = Int32.Parse(seconds);
        Console.WriteLine();
    
    } 
    public void Spinner(int secs)
    {
        int i = 0;
        //int readyTimer = secs;//seconds of a ready timer
        
        while (i<secs)
        {
            
            Console.Write("|");
            Thread.Sleep(250);//250 milliseconds * 4 stages of the animation = 1 second for each loop through.  
            
            Console.Write("\b");
            //Console.Write("");
            
            Console.Write("/");
            Thread.Sleep(250);

            Console.Write("\b");
            //Console.Write("");
            
            Console.Write("-");
            Thread.Sleep(250);

            Console.Write("\b");
            //Console.Write("");
            
            Console.Write("\\");
            Thread.Sleep(250);

            Console.Write("\b \b");
            //Console.Write(" ");
                    
            i++;
        }
        
    }
    public void GetReady(int secs)
    {
        Console.Clear();
        Console.WriteLine("Get ready...");//then spinner for 5 seconds
        Spinner(secs);
        Console.WriteLine();
        Console.WriteLine();
     
    }
public void CountDownTimer(int t)
    {
        int i = 0;        
        while (i<t)
        {
            Console.Write(t.ToString());//write the number as string to line
            Thread.Sleep(1000);//delay 1 second
            Console.Write("\b");//backspace the console line
            t--;
        }
        Console.Write(" ");
    }
public void EndText()
{
    Console.WriteLine();
    Console.WriteLine("Well Done!");
    Spinner(3);//will run the spinner for minium of 4 seconds
    Console.WriteLine();
    Console.WriteLine($"You have completed another {_seconds} seconds of the {_activityName} Activity.");
    Spinner(4);//run the spinner for 4 seconds
    Console.WriteLine();

}
public void DisplayRandomPrompt(List<string> list)
{
    int listSize = list.Count();//get the size of list and set to a local variable.
    Random rnd = new Random();//instantiate a random number class variable
    int randomNumber = rnd.Next(0, listSize);//get a random number and assign to an int variable
    Console.WriteLine($"---{list[randomNumber]}---");//use the random number to access and display prompt from list
    Console.WriteLine();//I want a return space after every random prompt given
}

public int ReturnRandomIndexNumberfromList(List<string> list)
{

    int listSize = list.Count();//get the size of list and set to a local variable.
    Random rnd = new Random();//instantiate a random number class variable
    int randomNumber = rnd.Next(0, listSize);//get a random number and assign to an int variable
    return randomNumber;
}

}








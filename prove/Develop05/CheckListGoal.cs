class ChecklistGoal : Goal

{
//member variables___________________________________________________________________

private int _numToComplete;//var to hold the number we whish to complete to mark as completed
private int _numCompleted;//var to hold the number we have completed
private int _bonusPoints;//var to hold the bonus points achieved when all done
private bool _giveBonus;
//Constructors_________________________________________________________________________

    public ChecklistGoal()
    {}//empty constructor to use in our program to first instantiate the object of this class
    public ChecklistGoal (string name, string description, int pointValue, bool isComplete,int numCompleted, int numToComplete, int bonusPoints) : base (name, description, pointValue, isComplete)
    {
        _numCompleted = numCompleted;
        _numToComplete = numToComplete;
        _bonusPoints = bonusPoints;

    }
    
//getters and setters____________________________________________________________________
    
    public void SetBonusPoints(int bonusPoints)
    {
        _bonusPoints = bonusPoints;
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public void SetNumToComplete(int numToComplete)
    {
        _numToComplete = numToComplete;
    }
    public int GetNumToComplete()
    {
        return _numToComplete;
    }
    public void SetNumCompleted(int numCompleted)
    {
        _numCompleted = numCompleted;
    }

//Methods______________________________________________________________________________


    override public void CreateGoalEntry()//this method will create a goal but we can override this in each class if we need to
{                                                   //We have to pass in the new goal from the main so it has something to populate
    
    Console.WriteLine("What is the name your goal?");
    SetName(Console.ReadLine());
    Console.WriteLine("Give a short description?");
    SetDescription(Console.ReadLine());
    Console.WriteLine("What is the amount of points associated with this goal?");
    SetPointValue(int.Parse(Console.ReadLine()));
    Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
    _numToComplete = int.Parse(Console.ReadLine());
    Console.WriteLine("What is the bonus for accomplishing this goal that many times? ");
    _bonusPoints = int.Parse(Console.ReadLine());
   
}
override public string WriteGoalToFileFormat()
{
    return $"{GetType().Name}:,{_name},{_description},{_pointValue},{_isComplete},{_numCompleted},{_numToComplete},{_bonusPoints}";//we'll use the getType method to add the type of class
}
override public void CheckStatusAndUpdate()// a polymorphic method we'll use to always set the status of complete to false
    {
        
    if (_numCompleted != _numToComplete)//if task not complete
    {
        ++_numCompleted;//increment this variable
        
        if (_numCompleted != _numToComplete)//then check these variables again
        {
        _isComplete = false;
        _givePoints = true;
        Console.WriteLine("Good job!...your own you way!");
        }
        else// if (_numCompleted == _numToComplete)
        {
            _isComplete = true;
            _givePoints = true;
            _giveBonus = true;
             Console.WriteLine($"AWESOME!! you earned {_pointValue} points plus {_bonusPoints} BONUS points.  The goal is now completed!");
        }
    }

    else
    {
        Console.WriteLine("This goal is already completed!");
        Console.WriteLine("Would you like to reset the goal?  Press y for Yes or any other key for No");
        string keyEntered = Console.ReadLine();
        if (keyEntered.ToLower() == "y")
        {
            _isComplete = false;
            _givePoints = false;
            _giveBonus = false;
            _numCompleted = 0;
            Console.WriteLine("The goal has been reset. Now you may again record the event to earn points");
        
        }
        else
        {
            Console.WriteLine("the goal will be kept as completed...No new points earned!");
            
        }
            _givePoints = false;//no points to be given
            _giveBonus = false;
       
    }  

    



    }
override public string DisplayGoal()
{
   return $" {_name} ({_description}) -- Currenlty completed: {_numCompleted}/{_numToComplete}";
}
override public int GiveAndShowPoints()
{
    if (_givePoints == true && _giveBonus == false)
    {
        Console.WriteLine($"Congratulations! You have earned {_pointValue} points! ");//display the points earned through the reference
        return _pointValue;
    }
    else if (_givePoints == true && _giveBonus == true)
    {
        Console.WriteLine($"Congratulations! You have earned {_pointValue + _bonusPoints} points! ");//display the points earned through the reference
        return _pointValue + _bonusPoints;
    }
    else
    {
        return 0;
    }
}
override public string DisplayStatus()//I learned about using a condition or Ternary operator to return a different value based on the bool...nice
{
if (_numToComplete != _numCompleted)
{
    return "[ ]";
}
else 
{
    _isComplete = true;
    return "[x]";
}
}
override public void ResetGoal()
{
    _isComplete = false;
    _numCompleted = 0;
}

}
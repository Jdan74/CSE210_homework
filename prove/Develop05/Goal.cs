class Goal

{
//member variables___________________________________________________________________
protected string _name = "";   
protected string _description = "";
protected int _pointValue;
protected bool _isComplete = false;
protected bool _givePoints = false;

//Constructors_________________________________________________________________________


    public Goal
    ()
    {
    }
    public Goal (string name, string description, int pointValue, bool isComplete)
    {
        _name = name;
        _description = description;
        _pointValue = pointValue;
        _isComplete = false;
        
    }

    
//getters and setters______________________________________________________________________________


    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public int GetPointValue()
    {
        return _pointValue;
    }
    public void SetPointValue(int pointValue)
    {
        _pointValue = pointValue;
    }
    public bool GetIsComplete()
    {
        return _isComplete;
    }
   
    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }


//Methods______________________________________________________________________

virtual public void CreateGoalEntry()//this method will create a goal but we can override this in each class if we need to
{                                                   //We have to pass in the new goal from the main so it has something to populate
    
    Console.WriteLine("What is the name your goal?");
    _name = Console.ReadLine();
    Console.WriteLine("Give a short description?");
    _description = Console.ReadLine();
    Console.WriteLine("What is the amount of points associated with this goal?");
   _pointValue = int.Parse(Console.ReadLine());
   _isComplete = false;
   
}

virtual public string DisplayGoal()
{
   return $" {_name} ({_description})";
}

virtual public string WriteGoalToFileFormat()
{
    return $"{GetType().Name}:,{_name},{_description},{_pointValue},{_isComplete}";//we'll use the getType method to add the type of class
}

virtual public string DisplayStatus()//I learned about using a condition or Ternary operator to return a different value based on the bool...nice
{
    return _isComplete ? "[x]" : "[ ]";
}

virtual public void CheckStatusAndUpdate()// a polymorphic method to check the status of the goal
{
    if (_isComplete == false)
    {
        _isComplete = true;
        _givePoints = true;
        Console.WriteLine("the goal is completed");
    }  

    else
    {
        Console.WriteLine("This goal is already completed!");
        Console.WriteLine("Would like to reset the goal?  Press y for Yes or any other key for No");
        string keyEntered = Console.ReadLine();
        if (keyEntered.ToLower() == "y")
        {
            _isComplete = false;
            Console.WriteLine("The goal has been reset. Now you may again record the event to earn points");
            
            //_numCompleted = 0;//for the checklist version
        }
        else
        {
            Console.WriteLine("the goal will be kept as completed...No new points earned!");
            
        }
            _givePoints = false;//no points to be given
    }  
       
    
}

virtual public int GiveAndShowPoints()
{
    if (_givePoints == true)
    {

        Console.WriteLine($"Congratuations! You have earned {_pointValue} points! ");//display the points earned through the reference
        return _pointValue;

    }
    else
    {
        //Console.WriteLine($"No points for you this time!");
        return 0;
    }
    
}
virtual public void ResetGoal()
{
    _isComplete = false;
}


}
class EternalGoal : Goal

{
//member variables___________________________________________________________________
//can use the parent variables
  
//Constructors_________________________________________________________________________

    public EternalGoal()
    { 
    }//empty constructor to use in our program to first instantiate the object of this class
    
    public EternalGoal (string name, string description, int pointValue, bool isComplete = false) : base (name, description, pointValue, isComplete)
    {
    }
    
//getters and setters____________________________________________________________________
    

//Methods______________________________________________________________________________
    
override public void CheckStatusAndUpdate()// a polymorphic method we'll use to always set the status of complete to false
    {
        _isComplete = false;
        _givePoints = true; //
    }


//should be able to use the create goal entry from my goal class

}
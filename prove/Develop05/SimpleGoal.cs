class SimpleGoal : Goal

{
//member variables___________________________________________________________________

    // just maybe one extra here, a bool to hand if completed, but I think instead I'll keep this in the parent
    // class as I will need it for 2 of the 3 child classes
    
    
//Constructors_________________________________________________________________________

    public SimpleGoal()
    {}//empty constructor to use in our program to first instantiate the object of this class
    public SimpleGoal (string name, string description, int pointValue, bool isComplete) : base (name, description, pointValue, isComplete)
    {
    }
    
//getters and setters____________________________________________________________________


//Methods______________________________________________________________________________
    
    
//should be able to use the create goal entry from my goal class

}
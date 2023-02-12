
class WritingAssignment : Assignment
{
    
    //member variables___________________________________________________________________
    private string _title = "";
  

//Constructors_________________________________________________________________________


    public WritingAssignment() 
    {
    }
    public WritingAssignment (string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
       
    }
    
//getters and setters______________________________________________________________________________


    public string GetTitle()
    {
        return _title;
    }
    public void SetTitle(string title)
    {
        _title = title;
    }

//Methods______________________________________________________________________

    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}"; //using a member variable and a base variable which has been set to protected
    }

}







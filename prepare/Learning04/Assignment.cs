class Assignment
{//member variables___________________________________________________________________
    protected string _studentName = "";//setting my variables to protected so they can be accessed by derived classes
    protected string _topic = "";

//Constructors_________________________________________________________________________


    public Assignment()
    {
    }
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    
//getters and setters______________________________________________________________________________


    public string GetStudentName()
    {
        return _studentName;
    }
    public void SetStudentName(string studentName)
    {
        _studentName = studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }
    public void SetTopic(string topic)
    {
        _topic = topic;
    }

//Methods______________________________________________________________________

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

}
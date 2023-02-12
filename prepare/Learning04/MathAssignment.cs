
class MathAssignment : Assignment
{//member variables___________________________________________________________________
    private string _textBookSection = "";
    private string _problems = "";

//Constructors_________________________________________________________________________


    public MathAssignment() 
    {
    }
    public MathAssignment(string studentName, string topic, string textBookSection, string problems) : base(studentName, topic)
    {
        _textBookSection = textBookSection;
        _problems = problems;
    }
    
//getters and setters______________________________________________________________________________


    public string GettextBookSectoin()
    {
        return _textBookSection;
    }
    public void SettextBookSection(string textBookSection)
    {
        _textBookSection = textBookSection;
    }
    public string GetProblems()
    {
        return _topic;
    }
    public void SetProblems(string topic)
    {
        _topic = topic;
    }

//Methods______________________________________________________________________

    public string GetHomeworkList()
    {
        return $"Section {_textBookSection} Problems {_problems}";
    }

}







class Pathology// a parent class to create the various pathology we might be interested in tracking
{
protected string _pathName;
protected string _pathDescription;
protected string _pathQuestion;

//Constructors
public Pathology ()
{


}
public Pathology (string pathName, string pathDescription, string pathQuestion, bool pathHas)
{
    _pathName = pathName;
    _pathDescription = pathDescription;
    _pathQuestion = pathQuestion;
    
}

public string PathName 
{
    get {return _pathName;}
    set {_pathName = value;}
}
public string PathDescription
{
     get {return _pathDescription;}
    set {_pathDescription = value;}
}
public string PathQuestion
{
     get {return _pathQuestion;}
    set {_pathQuestion = value;}
}


//methods----------------------------------------------------------------------------


public void DisplayPathologyNameDescriptionQuestion()
{
 Console.WriteLine($"{_pathName}: {_pathDescription}");
        Console.WriteLine();
        Console.WriteLine($"{_pathQuestion}");
        Console.WriteLine();

}

public static string DisplayUserFootPatholgyList(List<Pathology> userPathList)//this is Static so we can call it without instantiation of pathology
{
string pathListString = "";

 foreach (Pathology path in userPathList)
    {
        //return $"{path.PathName},";//this displays the names of each path
        pathListString = pathListString + path.PathName + ",";//concatinating the list of pathology
    
    }

    return pathListString;
}

public void DisplayPathologyName()
{
 Console.Write($" {_pathName},");
}


}
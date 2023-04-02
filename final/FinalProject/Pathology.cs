class Pathology// a parent class to create the various pathology we might be interested in tracking
{
protected string _pathName;
protected string _pathDescription;
protected string _pathQuestion;
protected bool _pathHas;

//Constructors
public Pathology ()
{
     

}
public Pathology (string pathName, string pathDescription, string pathQuestion, bool pathHas)
{
    _pathName = pathName;
    _pathDescription = pathDescription;
    _pathQuestion = pathQuestion;
    _pathHas = pathHas;

}
public Pathology (bool pathHas)  // a cosntructor to allow us to bass a bool and 
{
   

    _pathHas = pathHas;

}
//getters and setters - here we are creating properties to access our variables from elsewhere using the dot method


public bool PathHas 
{
    get {return _pathHas;}
    set {_pathHas = value;}
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

//public List<Pathology>  PathListAll {get ; set;}
//methods




public void DisplayPathologyNameDescriptionQuestion()
{
 Console.WriteLine($"{_pathName}: {_pathDescription}");
        Console.WriteLine();
        Console.WriteLine($"{_pathQuestion}");
        Console.WriteLine();

}

public static string DisplayUserFootPatholgyList(List<Pathology> userPathList)
{
string pathListString = "";
 foreach (Pathology path in userPathList)
    {
        //return $"{path.PathName},";//this displays the names of each path
        pathListString = pathListString + path.PathName;
    
    }

return pathListString;
}

public void DisplayPathologyName()
{
 Console.Write($" {_pathName},");
}


}
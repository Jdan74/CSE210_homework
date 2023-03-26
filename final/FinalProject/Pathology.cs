class Pathology// a parent class to create the various pathology o
{
protected string _pathName;
protected string _pathDescription;
protected string _pathQuestion;
protected bool _pathHas;//not sure yet if I'll need this


//name, affect on shoe fitting (larger toe box for hammertoes), heel pain, needs supportive insert
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

//methods

public virtual void AskAboutPathology()
{
    //we'll write the specifics for this in each of the child classes
}


}
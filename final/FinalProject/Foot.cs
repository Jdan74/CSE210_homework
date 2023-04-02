class Foot 

{
//member variables
private float _lengthMeasuredFoot;
private float _widthMeasuredFoot;
private Pathology _pathFlatFootFoot;
private Pathology _pathHeelPainFoot;
private Pathology _pathHammerToeFoot;
private List<Pathology> _pathListFoot;//list to hold just the path the foot has  // = new List<Pathology>();//we'll try this out....
private List<Pathology> _pathListAllPossible;//list to hold all available path

//constructors
public Foot ()// we need all these objects to instantiate as soon as any Foot object is created.  I first had these in the 2nd constructor and found that it wasn't working because I wasn't passing arguments.
{
    _pathListAllPossible = new List<Pathology>();//inst a empty list to hold all possible pathology

    _pathFlatFootFoot = new FlatFoot();//adding each pathology type to our list of all possible
    _pathListAllPossible.Add(_pathFlatFootFoot);
    _pathHeelPainFoot = new HeelPain();
    _pathListAllPossible.Add(_pathHeelPainFoot);
    _pathHammerToeFoot = new HammerToes();
    _pathListAllPossible.Add(_pathHammerToeFoot); 
    
    _pathListFoot = new List<Pathology>();// inst an empty list to hold foot specife pathology 
    if (_pathFlatFootFoot.PathHas == true)//looking at the values we instanting this specific list of pathyology that a person has.
    {
         _pathListFoot.Add(_pathFlatFootFoot);//adding the pathology their person list
        _pathFlatFootFoot.PathHas = true;//setting the value of _pathHas to true
    } 
    if (_pathHeelPainFoot.PathHas == true)
    {
        _pathListFoot.Add(_pathHeelPainFoot);
    } 
    if (_pathHammerToeFoot.PathHas == true)
    {
        _pathListFoot.Add(_pathHammerToeFoot);
    } 

}
public Foot (float lengthMeasuredFoot, float widthMeasuredFoot, params Pathology[] pathListFoot)//constroctor to take a length, width and any number of pathologies
{
    _lengthMeasuredFoot = lengthMeasuredFoot;
    _widthMeasuredFoot = widthMeasuredFoot; 
    _pathListFoot = new List<Pathology> (pathListFoot); // we'll the params to allow the constructor to accept any number of pathologies and put them into the list
}

//Creating Properties and their Getters and setters using one type of get and set method I learned about



public float LengthMeasuredFoot
{
    get { return _lengthMeasuredFoot;}
    set { _lengthMeasuredFoot = value;}
}
public float WidthMeasuredFoot
{
    get { return _widthMeasuredFoot;}
    set { _widthMeasuredFoot = value;}
}

public bool PathFlatFootFoot
{
    get { return _pathFlatFootFoot.PathHas;}
    set {_pathFlatFootFoot.PathHas = value;}
}
public bool PathHeelPainFoot
{
    get {return _pathHeelPainFoot.PathHas;}
    set {_pathHeelPainFoot.PathHas = value;}
}

public bool PathHammerToeFoot
{
    get {return _pathHammerToeFoot.PathHas;}
    set {_pathHammerToeFoot.PathHas = value;}
}
public List<Pathology> PathListFoot//list to hold the the pathologies that a person has
{
    get {return _pathListFoot;}
    set {_pathListFoot = value;}
}



// Methods

public void CreateFootSizeProfile()
{
    Console.Clear();
    Console.WriteLine("Now let's get some measurements of your feet...");
    Console.WriteLine();
    Console.WriteLine("What is the measured length of your foot from heel to tip of longest toe in cm?");
    _lengthMeasuredFoot = float.Parse(Console.ReadLine());
    Console.WriteLine("What is the measured Width of your foot at the the widest point in cm?");
    _widthMeasuredFoot = float.Parse(Console.ReadLine());
}

public void DisplayFootProfile()//will display a foot profile
{    
    //Console.Clear();
     Console.WriteLine($"    Foot length: {_lengthMeasuredFoot} ");
     Console.WriteLine($"    Foot width: {_widthMeasuredFoot} ");
     Console.Write("    Pathology: ");
     Console.Write(Pathology.DisplayUserFootPatholgyList(_pathListFoot));//using our static to get the path list
     
    //  foreach (Pathology path in _pathListFoot)
    // {

    //     path.DisplayPathologyName();//this displase the names of each pat
       
    // }
    
}

public void EditFootSizeProfile()
{
    Console.WriteLine("You have chosen to edit your foot profile.  Please make a selection of which item to edit.");


}

public void CreateFootPathologyList()//as a foot will have pathology, we should keep this function as part of the foot class, NOT the pathology class
{
Console.Clear();
Console.WriteLine("We'll now ask you about possible specific foot problems you might experience...");
Thread.Sleep(500);// wait 
Console.WriteLine();

string response = "";

foreach (Pathology pathology in _pathListAllPossible)//trying here to iterate through the list of all the child class pathologies one by one and if answere is true, that PathHas property set to true
    {
        Console.Clear();
        pathology.DisplayPathologyNameDescriptionQuestion();
        Console.WriteLine("Press y for YES or another other key for NO");
        response = Console.ReadLine().ToLower();
       
       if (response == "y")
        {
            Console.WriteLine("You have entered YES. This condition will be added to your profile\n");
            pathology.PathHas = true;//
            _pathListFoot.Add(pathology);
            Thread.Sleep(500);//wait 
            
        }
        else
        {
            Console.WriteLine("You have entered NO. This condition will NOT be added to your profile");
            pathology.PathHas = false;
            Thread.Sleep(500);//wait 
        }

    }
}

public void EditFootPathologyList()//as a foot will have pathology, we should keep this function as part of the foot class, NOT the pathology class
{

Console.WriteLine("We'll now ask you again about possible specific foot problems you might experience."); 
Console.WriteLine();

//Pathology path = new Pathology();//need to instantiate a Pathology object
string response = "";

foreach (Pathology pathology in _pathListAllPossible)
    {
           
        pathology.DisplayPathologyNameDescriptionQuestion();
        Console.WriteLine("Press y for YES or another other key for NO");
        response = Console.ReadLine().ToLower();
       
       if (response == "y")
        {
            Console.WriteLine("You have entered YES. This condition will be added to your profile\n");
            pathology.PathHas = true;
            
        }
        else
        {
            Console.WriteLine("You have entered NO. This condition will NOT be added to your profile");
            pathology.PathHas = false;
        }
        
        

    }
}


}
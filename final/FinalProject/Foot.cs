class Foot 

{
//member variables
private float _lengthMeasuredFoot;
private float _widthMeasuredFoot;
private List<Pathology> _pathListFoot;// = new List<Pathology>();//list to hold just the path the foot has  // = new List<Pathology>();//we'll try this out....
private List<Pathology> _pathListAllPossible;//list to hold all available path

//constructors
public Foot ()//this one is being used when we create a new foot profile.
{
   
_pathListFoot = new List<Pathology>(); // we'll the params to allow the constructor to accept any number of pathologies and put them into the list

    _pathListAllPossible = new List<Pathology>();//inst a empty list to hold all possible pathology
    FlatFoot _pathFlatFootFoot = new FlatFoot();//adding each pathology type to our list of all possible
    _pathListAllPossible.Add(_pathFlatFootFoot);
    HeelPain _pathHeelPainFoot = new HeelPain();
    _pathListAllPossible.Add(_pathHeelPainFoot);
    HammerToes _pathHammerToeFoot = new HammerToes();
    _pathListAllPossible.Add(_pathHammerToeFoot); 

}
public Foot (float lengthMeasuredFoot, float widthMeasuredFoot, params Pathology[] pathListFoot)//constructor to take a length, width and any number of pathologies us the the params keyword
{                                                                                                  //this one is being used when we read from the data base and populate the list.  
                                                                                                //this may be causing the issue that I seem to have 2 different instances of the pathology list
    _lengthMeasuredFoot = lengthMeasuredFoot;
    _widthMeasuredFoot = widthMeasuredFoot; 
    
    _pathListFoot = new List<Pathology> (pathListFoot); // we'll the params to allow the constructor to accept any number of pathologies and put them into the list

    _pathListAllPossible = new List<Pathology>();//inst a empty list to hold all possible pathology
    FlatFoot _pathFlatFootFoot = new FlatFoot();//adding each pathology type to our list of all possible
    _pathListAllPossible.Add(_pathFlatFootFoot);
    HeelPain _pathHeelPainFoot = new HeelPain();
    _pathListAllPossible.Add(_pathHeelPainFoot);
    HammerToes _pathHammerToeFoot = new HammerToes();
    _pathListAllPossible.Add(_pathHammerToeFoot); 

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
  
     Console.WriteLine($"    Foot length: {_lengthMeasuredFoot} ");
     Console.WriteLine($"    Foot width: {_widthMeasuredFoot} ");
     Console.Write("    Pathology: ");
     Console.Write(Pathology.DisplayUserFootPatholgyList(_pathListFoot));//using our static to get the path list
   
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
            //pathology.PathHas = true;// don't need this as we are only going to add the item to our list if they have it.  Could eliminate this bool from the pathology class?
            if (!_pathListFoot.Contains(pathology))//checking to see if already in list, if not, we'll add, if is, leave alone
            {
                _pathListFoot.Add(pathology);
                Thread.Sleep(500);//wait 
            }
            else 
            {
                //already in the list, so do nothing
            }
            
        
        }
        else
        {
            Console.WriteLine("You have entered NO. This condition will NOT be added to your profile");
            //pathology.PathHas = false;
            if(_pathListFoot.Contains(pathology))
            {
                _pathListFoot.Remove(pathology);
            Thread.Sleep(500);//wait 
            }
            else
            {
                //not in the list, so do nothing
            }
            
        }

    }
}

// public void EditFootPathologyList()//as a foot will have pathology, we should keep this function as part of the foot class, NOT the pathology class
// {

// Console.WriteLine("We'll now ask you again about possible specific foot problems you might experience."); 
// Console.WriteLine();

// //Pathology path = new Pathology();//need to instantiate a Pathology object
// string response = "";

// foreach (Pathology pathology in _pathListAllPossible)
//     {
           
//         pathology.DisplayPathologyNameDescriptionQuestion();
//         Console.WriteLine("Press y for YES or another other key for NO");
//         response = Console.ReadLine().ToLower();
       
//        if (response == "y")
//         {
//             Console.WriteLine("You have entered YES. This condition will be added to your profile\n");
//             pathology.PathHas = true;
            
//         }
//         else
//         {
//             Console.WriteLine("You have entered NO. This condition will NOT be added to your profile");
//             pathology.PathHas = false;
//         }
        
        

//     }
// }


}
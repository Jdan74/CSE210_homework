class User

{
//variables
private string _nameFirst;
private string _nameLast;
private Foot _footProfile;
private List<Shoe> _recShoeList;


//constuctors - here we'll instantiate the objects we need for every user
public User()//created with every new user
{
    _footProfile = new Foot();//making a foot
    _recShoeList = new List<Shoe>();// a list to hold the shoes recommened for this user    
}

public User(string nameLast, string nameFirst, Foot footProfile)
{
    _nameFirst = nameFirst;
    _nameLast =  nameLast;
    _footProfile = footProfile;
}

public User(string nameLast, string nameFirst, float footLength, float footWidth, bool hasFlatFoot, bool hasHeelPain, bool hasHammerToe)//, List<Pathology> footPathList)
{
    
    _nameFirst = nameFirst;
    _nameLast =  nameLast;

    _footProfile = new Foot();//making a foot
    
    _footProfile.LengthMeasuredFoot = footLength; //passing the measurements to the variables
    _footProfile.WidthMeasuredFoot = footWidth;

    _footProfile.PathFlatFootFoot = hasFlatFoot; //passing the pathologies to the foot profile based on the bools
    // if (hasFlatFoot == true)
    // {
    //     _footProfile.PathFlatFootFoot.PathHas = true;
    // }

    _footProfile.PathHeelPainFoot = hasHeelPain;
    _footProfile.PathHammerToeFoot = hasHammerToe;
    // these values should allow for creating of the list of pathology in the pathology constructor

}

// properties, getters and setters-----------------------------------------------------------------------------------------------------------------------------

public string NameFirst//here I'm trying a different notation that can be used to create a property and then use the property to directly access the private member variable. I like this method as it is easier to type
    {
        get => _nameFirst;
        set => _nameFirst = value;
    }
public string NameLast
{
    get => _nameLast;
    set => _nameLast = value;
}
public Foot FootProfile
{
    get => _footProfile;
    set => _footProfile = value;
}
public List<Shoe> RecShoeList
{
    get => _recShoeList;
    set => _recShoeList = value;
}
    


//Methods-----------------------------------------------------------------------------------------------------------------------------
public void CreateProfile()
{
//first create our user info
Console.Clear();
Console.WriteLine("Let's get your basic info...");
Console.WriteLine();
Console.WriteLine("What is your first name?");
_nameFirst = Console.ReadLine().Trim();
Console.WriteLine("What is your last name?");
_nameLast = Console.ReadLine().Trim();
//then create our foot size
_footProfile.CreateFootSizeProfile();

//then create our foot patholgy info
_footProfile.CreateFootPathologyList();

}

public void DisplayProfileLong()// a method to display the foot profile in a single line format

{
Console.Write($"{_nameLast},{_nameFirst},{_footProfile.LengthMeasuredFoot},{_footProfile.WidthMeasuredFoot},");

foreach (Pathology path in _footProfile.PathListFoot)
{
    Console.Write($"{path.PathName},");
}
Console.WriteLine();
//PathFlatFootFoot},{_footProfile.PathHeelPainFoot},{_footProfile.PathHammerToeFoot}");
}

public void DisplayProfile()
{
   
    Console.Clear();
    Console.WriteLine("Here is your profile.");
    Console.WriteLine();
    Console.WriteLine($"First name: {_nameFirst}");
    Console.WriteLine($"Last name: {_nameLast}");
    _footProfile.DisplayFootProfile();//display foot profile
    Console.WriteLine();
    Console.WriteLine("press any key to quit viewing and return to previous menu");
    
    
    bool done = false;
    while (!done)//a loop set to true to keep us here until we break out using break;
    {
            
        if (Console.KeyAvailable)//if a key has been pressed
            {
                Console.ReadKey(true);//cool method argument we are using here...this will see if any key has been pressed but don't write it to console
                done = true;//esape out of this back to meny

            }
        
    }      

}

public static User FindProfile(List<User> users)
{
bool userFoundBool = false;
User userFound = new User();//inst a new user to use if we find a match
    
    //while (!userFoundBool)
    
        Console.WriteLine("What is the first name?");
        string nameFirst = Console.ReadLine();
        Console.WriteLine("What is the last name?");
        string nameLast = Console.ReadLine();

                    
                foreach (User user in users)
                {
                    if(user._nameLast == nameLast && user._nameFirst == nameFirst)
                    {
                        userFound = user;//setting our userFound to the user
                
                        userFoundBool = true;

                    }
                    //else will default to false
                }    
                    
                if (userFoundBool == true)

                {
                    //userFound.DisplayProfile();
                    userFound.DisplayProfileLong();
                    Thread.Sleep(2000);

                }

                else
                {

                    Console.Write("...no match, going back to menu, feel free to try again");
                    Thread.Sleep(2000);
                    
                }
                       
                        
                

                
        
            
        

    
    
    return userFound;
}

public void EditProfile()
{

    bool done = false;
    while(!done)
    {

        Console.Clear();
        Console.WriteLine("Here is your profile.\nEnter the number of the item you wish to edit, or any other key to quit the editing menu.");

        Console.WriteLine($"1.  Name: {_nameFirst} {_nameLast}");
      
        Console.WriteLine($"2.  Foot Profile: ");
        
        _footProfile.DisplayFootProfile();//need to run method to display their pathology

        string choice;
        choice = Console.ReadLine();
            
            if (choice == "1")//change name
            {
                string choiceNameEdit;
                Console.WriteLine("You have chosen to change your name. Enter a number selection");
                Console.WriteLine("1. Edit First Name");
                Console.WriteLine("2. Edit Last Name"); 
                
            

                choiceNameEdit = Console.ReadLine();
                if (choiceNameEdit == "1")
                {
                    Console.WriteLine("Enter the new First name:");
                    _nameFirst = Console.ReadLine();
                }
                else if (choiceNameEdit == "2")
                {
                     Console.WriteLine("Enter the new Last name:");
                    _nameLast = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have made an ivalid entry");
                }
                
            }
            else if (choice =="2")//change foot profile details
            {
                string choiceProfileEdit;
                Console.WriteLine("You have chosen to edit your foot profile. Enter a number selection.");
                Console.WriteLine("1. Edit Foot Size");
                Console.WriteLine("2. Edit Pathology");

                choiceProfileEdit = Console.ReadLine();
                if (choiceProfileEdit == "1")
                {
                    
                    _footProfile.CreateFootSizeProfile();//get foot sizes again
                    
                }
                else if (choiceProfileEdit == "2")
                {
                    _footProfile.CreateFootPathologyList();
                }
                else
                {
                    Console.WriteLine("You have made an ivalid entry");
                }



            }
            
            
            
            // else if (choice =="3")
            // {
                
                
                
            //     Console.WriteLine("Enter the new foot length:");
            //     _footProfile.LengthMeasuredFoot = int.Parse(Console.ReadLine());
        
            // }
            // else if (choice =="4")
            // {
            //     Console.WriteLine("Enter the new foot width");
            //     _footProfile.WidthMeasuredFoot = int.Parse(Console.ReadLine());
            // }
            // else if (choice == "5")
            // {
            //     Console.WriteLine("Choose the item of pathology you whish to change; ");
                
            //     foreach (Pathology path in _footProfile.PathListFoot)
            //     {
            //         int i = 1;
            //         if (path.PathHas == true)//list out the true pathologies with numbers
            //         {
            //             Console.WriteLine($"{i}. {path.PathName} ");
            //             i++;
            //         }
            //     }
                

            // }
            else 
            {
                done = true;
            }
    }

}
public string CreateNewUserFileEntry()

{
return $"\n{_nameLast},{_nameFirst},{_footProfile.LengthMeasuredFoot},{_footProfile.WidthMeasuredFoot},{_footProfile.PathFlatFootFoot},{_footProfile.PathHeelPainFoot},{_footProfile.PathHammerToeFoot}";
}

public string CreateUserFileEntry(List<User> users)

{
//return $"{_nameLast},{_nameFirst},{_footProfile.LengthMeasuredFoot},{_footProfile.WidthMeasuredFoot},{_footProfile.PathFlatFootFoot},{_footProfile.PathHeelPainFoot},{_footProfile.PathHammerToeFoot}";
string a =  $"{_nameLast},{_nameFirst},{_footProfile.LengthMeasuredFoot},{_footProfile.WidthMeasuredFoot}";
string b = Pathology.DisplayUserFootPatholgyList(_footProfile.PathListFoot);
string c = Pathology.DisplayUserFootPatholgyList(_footProfile.PathListFoot);
return a + b + c;
}

}
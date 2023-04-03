class User

{
//variables
private string _nameFirst;
private string _nameLast;
private Foot _footProfile = new Foot();
//private List<Shoe> _recShoeList = new List<Shoe>();//could use this in the future, to save their shoe list in their profile


//constuctors - here we'll instantiate the objects we need for every user
public User()//created with every new user
{
    
}

public User(string nameLast, string nameFirst, Foot footProfile)
{
    _nameFirst = nameFirst;
    _nameLast =  nameLast;
    _footProfile = footProfile;
    
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
// public List<Shoe> RecShoeList
// {
//     get => _recShoeList;
//     set => _recShoeList = value;
// }
    


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

public User FindProfile(List<User> users)
{
bool userFoundBool = false;
User userFound;// = new User();//inst a new user to use if we find a match
    
        Console.WriteLine("What is the first name?");
        string nameFirst = Console.ReadLine();
        Console.WriteLine("What is the last name?");
        string nameLast = Console.ReadLine();
                    
                foreach (User user in users)
                {
                    if(user._nameLast == nameLast && user._nameFirst == nameFirst)
                    {
                        userFound = new User(user._nameLast, user._nameFirst, user.FootProfile);//try to use the same constructor so we can keep one instance going?
                            //user;//setting our userFound to the user
                        userFound.DisplayProfileLong();
                        Thread.Sleep(2000);
                        userFoundBool = true;
                        return userFound;
                    }
                    else
                    {
                        return null;
                    }
                    //else will default to false
                }    
                    
                if (userFoundBool == false)
                {
                    Console.Write("...no match, going back to menu, feel free to try again");
                    Thread.Sleep(2000);
                    //userFound.DisplayProfile();
                   return null;
                }
            return null;
}
public void EditProfile()
{

    bool done = false;
    while(!done)
    {

        Console.Clear();
        Console.WriteLine("Here is your profile. Enter the number of the item you wish to edit, or any other key to quit the editing menu.");

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
            
        
            else 
            {
                done = true;
            }
    }

}


public string CreateUserFileEntry()//List<User> users)

{
string a =  $"{_nameLast},{_nameFirst},{_footProfile.LengthMeasuredFoot},{_footProfile.WidthMeasuredFoot},";
string b = Pathology.DisplayUserFootPatholgyList(_footProfile.PathListFoot);
return a + b;
}

public static List<User> LoadUserListFromFile()
{
    bool done3 = false;
    List<User> users = new List<User>();
    while (!done3)
    {
        string userFilePath = "newusers.txt";
                                
                                
        Console.WriteLine("Attempting to load the Default user database...");
                                
        try//using a try catch block to handle if there is no file found
        {
            string[] lines = File.ReadAllLines(userFilePath);
                                                    
            foreach (string line in lines)
            {
                string[] index = line.Split(",");//getting the data from index 0-3
                string lastName = index[0];
                string firstName = index[1];
                float footLength = float.Parse(index[2]);
                float footWidth = float.Parse(index[3]);
                
                List<Pathology> listPath = new List<Pathology>();//creating a list of path to populate
                for (int x = 4; x < index.Length; x++)//we need to iterate just through the indices after the ones not in a list using the index.Length to read the length of the line
                {
                    
                    string pathtype = index[x];
                    if (pathtype == "Flat Feet")
                    {
                        FlatFoot flatFoot = new FlatFoot();
                        listPath.Add(flatFoot);
                    }
                    else if (pathtype == "Heel Pain")
                    {
                        HeelPain heelPain = new HeelPain();
                        listPath.Add(heelPain);
                    }
                    else if (pathtype == "Hammer Toes")
                    {
                        HammerToes hammerToes = new HammerToes();
                        listPath.Add(hammerToes);
                    }
                                            
                }
                
                Foot newFoot = new Foot(footLength,footWidth,listPath.ToArray());// instantiating a foot object. NOTE we had to use the ToArray() method on our list so as to pass each one as an argument 
                User userFromFile = new User(lastName,firstName,newFoot);
                
                users.Add(userFromFile);//adding to our user list
                
            }
                                    

            done3 = true;
            
        }

        catch (FileNotFoundException)//learned to use a try catch block to throw this exception
        {
            Console.WriteLine("The User file did not load or does not exist...please contact an administator");
            done3 = false;//this will keep us in the loop until we write in a legit file.  
            //I might want to add an option to escape out of this in case you don't know the main menu
            return null;
        }



    }
                        
return users;

}


    
}
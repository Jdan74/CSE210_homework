using System;
using System.IO;

class Program
{
   
    static void Main(string[] args)
    {
               
    Shoe newShoe = null;
    User newUser = null;// = new User();//instantiating a newUser to use for new proviles or loading a profile
    List<Shoe> shoes = null;//new List<Shoe>();
    List<User> users = null;// = new List<User>();
    List<Shoe> recShoes = new List<Shoe>();//makeing a new list to hold the shoe recommenddations from our shoefitter
    ShoeFitter shoeFitter = new ShoeFitter();
    string userFilePath = "";
    string input;
    bool exit = false;
    
    Console.Clear();
    while (exit == false)// a loop to keep us in the main menu until you want to exit.  We'll use cases for the selections
    {
        Console.WriteLine("Welcome to FIT THE FOOT shoe recommendation program");
        Console.WriteLine("1. User");
        Console.WriteLine("2. Admin");
        Console.WriteLine("3. Exit"); 
        Console.WriteLine("Please make a selection");
        input = Console.ReadLine();
    
        switch (input)
        {
            case "1":
            string input1;
            bool exit1 = false;
            while (exit1 == false)// a loop2 for this menu
            {           
                Console.Clear();
                Console.WriteLine("Welcome to the user menu.  Please make a selection.");
                Console.WriteLine("1. Create your profile");//working
                Console.WriteLine("2. Search and load your profile");//working
                Console.WriteLine("3. View your profile");//working
                Console.WriteLine("4. Edit your profile");//working but won't edit pathology correctly at times...i think it's an instance issue?
                Console.WriteLine("5. Run the Shoe Fitting Program ");//working
                Console.WriteLine("6. View your recommended Shoe List");//working
                Console.WriteLine("7. Exit to main menu");//working
                input1 = Console.ReadLine();
                switch (input1)
                {
                    case "1"://create a profile=================================working
                    Console.WriteLine("Create a profile");
                    
                    if (newUser == null)//check to see if we have already instantiated a newUser so they can't make 2 profiles.
                    {
                        newUser = new User();//instantiating a newUser from the basic constructor
                        newUser.CreateProfile();

                        if (users == null)//check to see if the uses list has already been created or populated
                        {
                            users = User.LoadUserListFromFile();
                        }
                        users.Add(newUser);// maybe we don't want to do this but rather just always ad the user to the file only
                        userFilePath = "newusers.txt";
                        using (StreamWriter writer = new StreamWriter(userFilePath, true))
                        {
                            writer.WriteLine(newUser.CreateUserFileEntry());//this method will insert new line and add it to the end of the list that is already up
                        }

                    }
                    else
                    {
                        Console.WriteLine("You're profile has already been created!  Please Select Edit if you need to make changes.");
                        Thread.Sleep(2000);
                    }
                    
                    break;//break from case 1
                    

                    case "2":
                    Console.WriteLine("Search for a profile");
                    
                    
                    if (newUser == null)
                    {
                        if (users == null)
                        {
                            Console.WriteLine("Loading the User Database...");
                            Thread.Sleep(2000);
                            users = User.LoadUserListFromFile();//using our static User Class method to get the users list from our default file
                            newUser = new User();

                            newUser = newUser.FindProfile(users);//now using our static User Class method to find the user we want and set it to newUser
                        }
                   
                        else
                        {
                            newUser = newUser.FindProfile(users);//using a STATIC method here because I want the method to GIVE me and instance that doesn't yet exist.
                                //passing the users list to our method to find a person
                                //need to return the user file data here to populate a user
                        }

                    } 
                   
                    else
                    {
                        Console.WriteLine("Your profile is already Loaded.");
                        Thread.Sleep(2000);
                    }

                    break;


                    case "3":
                    Console.WriteLine("View your profile");
                    
                    if (newUser == null)
                    {
                        Console.WriteLine("You have not yet created or opened a user profile");
                        Thread.Sleep(1500);

                        //run openprofile()
                    }
                    else 
                    {
                        newUser.DisplayProfile();
                    
                    }
                   break;//break from case 2 
                    
                    case "4":
                    Console.WriteLine("Edit your profile");//not working yet
                    newUser.EditProfile();
                    break;//break from case 2

                    
                    case "5":
                    if (newUser != null && shoes != null)
                    {
                        Console.WriteLine("Let's find A Shoe that Fits");//not working yet
                        Console.WriteLine("Running the Shoe Fitting Program....");
                        Thread.Sleep(2000);
                        
                        recShoes= shoeFitter.RunShoeFitter(newUser.FootProfile, shoes);
                
                        shoeFitter.DisplayShoeFitterList(recShoes);
                        Console.WriteLine("press any key to leave this list...");
                        Console.ReadKey();
                        
                    }
                    else if (newUser == null && shoes !=null)
                    {
                        Console.Write("You must first create or open a profile");
                        Thread.Sleep(2000);
                    }
                    else if (newUser != null && shoes ==null)
                    {
                        Console.Write("There is no Shoe database Open, please contact an administrator to load the file from the admin menu");
                        Thread.Sleep(2000);

                    }
                    else
                    {
                        Console.WriteLine("You must first create or open a profile...AND...");
                        Console.WriteLine ("There is no Shoe database Open, please contact an administrator to load the file from the admin menu");
                        Thread.Sleep(3000);
                    }
                    
        
                    break;//break fromcase 5
                    
                    case "6":
                    Console.WriteLine("View your recommended Shoe List");//working 
                    if (recShoes != null)
                    {
                        shoeFitter.DisplayShoeFitterList(recShoes);
                        Console.WriteLine("press any key to leave this list...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You have not yet run the Shoe Finder Program....");
                        Thread.Sleep(2000);
                    }


                    
                    break;//break fromcase 6

                    case "7":
                    Console.WriteLine("4. Exit to main menu");//working
                    exit1 = true;//allow us to exit the loop
                    Console.Clear();
                    break;//break from case 7

                    
                    default:
                    Console.WriteLine("you have made an invalid selection.");
                    continue; //this will put us back at the beginning of the loop again

                }      
                
            }
            break;//break from case 1

            case "2":
            string input2;
            bool exit2 = false;
            while (exit2 == false)// a loop2 for this menu and add logic to see if we have already instantiated a user?
            {
                Console.WriteLine("Welcome to the Admin menu.  Please make a selection.");
                Console.WriteLine("1. Add a shoe to the database");//working
                Console.WriteLine("2. Delete a shoe in the database");//working
                Console.WriteLine("3. Display shoes list");//working
                Console.WriteLine("4. Edit a shoe in the Database");// working except for not the path update
                Console.WriteLine("5. Load a Shoe File");//working
                Console.WriteLine("6. Save the Shoe File");//working
                Console.WriteLine("7. Load a User List");//working
                Console.WriteLine("8. Display the User List");//working
                Console.WriteLine("9. Save the User List");//working
                Console.WriteLine("0. Exit");//working
                input2 = Console.ReadLine();
                switch(input2)
                {
                    case "1"://functioning
                    if (shoes != null)
                    {

                        if (newShoe == null)
                        {
                            Console.WriteLine("Add a new shoe to the database");
                            newShoe = new Shoe();
                            newShoe.CreateShoe();
                            //shoes = new List<Shoe>();//inst our list
                            shoes.Add(newShoe);
                        }

                        else
                        {
                            Console.WriteLine("a newShoe has already been created.  You must first Save the Shoe File in order to enter a new one");
                        }
                                           
                    }

                    else//shoes is null so we need to open the file first
                    {
                        Console.WriteLine("To create a shoe you must Load a Shoe File");
                        Thread.Sleep(2000);
                    }
                    
                    
                    
                    break;//break from case 1
                
                    
                    case "2"://functioning
                    if (shoes != null)
                    {
                        Console.WriteLine("Delete a shoe in the database");
                        Console.WriteLine();
                        Console.WriteLine("Dispaying the Numbered Shoes List...");
                        Console.WriteLine();
                        int index1 = 1;
                        foreach (Shoe shoe in shoes)
                        {
                            Console.Write($"{index1}. ");
                            shoe.DisplayShoeDetails();
                            index1++;
                        }
                        Console.WriteLine("Enter the number of the shoe you wish to remove");
                        int choice;
                        choice = int.Parse(Console.ReadLine());//NO logic here yet to control for wrong entries
                        shoes.RemoveAt(choice - 1);
                        Console.WriteLine($"Shoe number {choice} has been removed from the list.");

                    }
                    else
                    {
                        Console.WriteLine("Please Load the Shoe Database first!");
                        Thread.Sleep(2000);
                    }


                    
                    break;//break from case 3
                    
                    case "3"://functioning
                    if (shoes != null)
                    {
                        Console.WriteLine("Dispaying the Numbered Shoes List...");
                        Console.WriteLine();
                        int index2 = 1;
                        foreach (Shoe shoe in shoes)
                        {
                            Console.Write($"{index2}. ");
                            shoe.DisplayShoeDetails();
                            index2++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Load a shoe database first...");
                        Thread.Sleep(2000);
                    }

                   
                    break;//break from case 4
                    
                    case "4"://functioning

                    if (shoes != null)
                    {
                        int index3 = 1;
                        Console.WriteLine("Edit a shoe in the Database");
                        Console.WriteLine("Displaying the Numbered Shoe List...");// need logic here to handle if database is empty?
                    
                  
                        foreach (Shoe shoe in shoes)
                        {
                
                            Console.Write($"{index3}. ");
                            shoe.DisplayShoeDetails();
                            index3++;
                        
                        }
                        
                        bool done2 = false;
                        while (!done2)
                        {
                            Console.WriteLine("Enter the number of the shoe you wish to edit.");
                            string selectionString = Console.ReadLine();
                            //nt selectionInt;
                            if (int.TryParse(selectionString, out int selectionInt)  && selectionInt <= index3-1 && selectionInt !=0) // if the input is a number and it is equal or less than the max index and it is not zero
                            {
                                Console.WriteLine("Selected Shoe: ");
                
                                shoes[selectionInt - 1].EditShoe();
                                done2 = true;
                            }
                            else
                            {
                                Console.WriteLine("You have made an invalid entry");
                                done2 = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Load a valid shoe list!");
                        Thread.Sleep(2000);
                    }
                    
                    break;
                    
                    case "5"://load a shoe file
                    if (shoes == null)
                    {
                        
                        bool done1 = false;
                        while (!done1)
                        {
                            string file = ""; 
                            shoes = new List<Shoe>();
                            Console.WriteLine("Please enter a .txt file containg the shoe database: ");
                            file = Console.ReadLine();
                            try//learned about and decided to use a try catch block to handle if there is no file found
                            {
                                string[] lines = File.ReadAllLines(file);
                                foreach (string line in lines)
                                {
                                    string[] index = line.Split(",");
                                    string shoeBrand = index[0];
                                    string shoeModel = index[1];
                                    float shoeLength = float.Parse(index[2]);
                                    string shoeWidth = index[3];
                                    float shoeLengthMeasured = float.Parse(index[4]);
                                    float shoeWidthMeasured = float.Parse(index[5]);

                                    List<Pathology> listPathShoe = new List<Pathology>();
                                    for (int x = 6; x < index.Length; x++)// a for loop to get through any other pathology objects 
                                    {
                                        string pathtype = index[x];

                                        if (pathtype == "Flat Feet")
                                        {
                                            FlatFoot flatFoot = new FlatFoot();
                                            listPathShoe.Add(flatFoot);
                                        }
                                        else if (pathtype == "Heel Pain")
                                        {
                                            HeelPain heelPain = new HeelPain();
                                            listPathShoe.Add(heelPain);
                                        }
                                        else if (pathtype == "Hammer Toes")
                                        {
                                            HammerToes hammerToes = new HammerToes();
                                            listPathShoe.Add(hammerToes);
                                        }

                                
                                    
                                    }
                                    newShoe = new Shoe(shoeBrand,shoeModel,shoeLength,shoeWidth,shoeLengthMeasured,shoeWidthMeasured,listPathShoe.ToArray());
                                    shoes.Add(newShoe);//adding to our shoe list
                                                    
                                    
                                }
                                done1 = true;
                            }
                            catch (FileNotFoundException)//leaned to use a try catch block to throw this exception
                            {
                                Console.WriteLine("The File you have reqested does not exit");
                                done1 = false;//this will keep us in the loop until we write in a legit file.  
                                //I might want to add an option to escape out of this in case you don't know the main menu
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("A shoe file is already open...");
                        Thread.Sleep(2000);
                    }
                    
                    newShoe = null;////////////////////this should all for a newShoe to me created again
                    break;
                    
                    case "6"://functioning -- saving the shoe list to the shoe file
                    Console.WriteLine("Please enter a file name to save: ");
                    string fileName = Console.ReadLine();
                    
                    using(StreamWriter writer = new StreamWriter(fileName))//instantiating our streamwriter
                    {

                        foreach (Shoe shoe in shoes)//interate through our list of shoes to write each one to the path
                        {
                            writer.WriteLine(shoe.CreateNewShoeFileEntry());//calling our shoe file format method to write each one to the file
                            
                        }
                    }
                    newShoe = null;/////////////////// I think this will work to make the newShoe null again after the list of shoes has been saved.
                    break;



                    case "7"://load the user list
                    if (users == null)
                    {
                        Console.WriteLine("The User List is Loading...");
                        Thread.Sleep(2000);
                        users = User.LoadUserListFromFile();
                    }
                    else
                    {
                        Console.WriteLine("The User List is already Loaded");
                        Thread.Sleep(2000);
                    }
                
                    break;

                    case "8":
                    Console.WriteLine("Displaying the user list...");
                    int i = 1;

                    if (users == null)
                    {
                        Console.WriteLine("the users list is null");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        foreach (User user in users)
                        {   
                            Console.Write($"{i}. ");
                            user.DisplayProfileLong();
                            i++;
                            
                        }
                    }
                    
                    break;

                    case "9"://saving the user list to a file
                    Console.WriteLine("Saving the user list...");
                     Console.WriteLine("Please enter a file name to save: ");
                    string userFileName = Console.ReadLine();
                    
                    using(StreamWriter writer = new StreamWriter(userFileName))//instantiating our streamwriter
                    {

                        foreach (User user in users)//interate through our list of shoes to write each one to the path
                        {
                            writer.WriteLine(user.CreateUserFileEntry());//calling our shoe file format method to write each one to the file
                        
                        }
                        
                    }
                    break;


                    case "0"://functioning 
                    Console.WriteLine("Exit to main menu");
                    exit2 = true;//allow us to exit the loop
                    break;//break from this case and exit the loop
 
                    default://this is what is said if none of the cases are selected
                    Console.WriteLine("you have made an invalid selection.");
                    continue;  //this will put us back at the beginning of this loop again

                }
            }
            
            break;//break from case 2

            case "3"://functioning
            
            Console.WriteLine("Exiting the program....");
            exit = true;//change the state so we can exit the loop and get out of the program
            break;//break and exit the program
            
            default:
            Console.WriteLine("you have made an invalid selection.");
            continue;//this will put us back at the beginning of this loop again
            
        }
   
    }
    
    }

}
using System;
using System.IO;

class Program
{
   


    static void Main(string[] args)
    {
               
    //create our lists to hold the shoes and users
    User newUser = null;// = new User();//instantiating a newUser to use for new proviles or loading a profile
    //Foot newFoot = new Foot();// inst a new foot
    List<Shoe> shoes = new List<Shoe>();
    List<User> users = new List<User>();
    string userFilePath = "";




    string input;
    bool exit = false;
    //bool shoeData = false;
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
                Console.WriteLine("1. Create your profile");
                Console.WriteLine("2. Search and load your profile");
                Console.WriteLine("3. View your profile");
                Console.WriteLine("4. Edit your profile");
                Console.WriteLine("5. Delete your profile ");//not working yet
                Console.WriteLine("6. Find A Shoe that Fits ");//not working yet
                Console.WriteLine("7. View your recommended Shoe List");//not working yet
                Console.WriteLine("8. Exit to main menu");
                input1 = Console.ReadLine();
                switch (input1)
                {
                    case "1":
                    Console.WriteLine("Create a profile");
                    
                    if (newUser == null)//check to see if we have already instantiated a newUser so they can't make 2 profiles.
                    {
                        newUser = new User();//instantiating a newUser from the basic constructor
                        newUser.CreateProfile();
                        users.Add(newUser);// maybe we don't want to do this but rather just always ad the user to the file only
                        userFilePath = "users.txt";
                        using (StreamWriter writer = new StreamWriter(userFilePath, true))
                        {
                            writer.WriteLine(newUser.CreateUserFileEntry());
                        }


                        //add the user to the end of the file
                    }
                    else
                    {
                        Console.WriteLine("You're profile has already been created!  Please Select Edit if you need to make changes.");
                        Thread.Sleep(1000);
                    }
                    break;//break from case 1
                    

                    case "2":
                    Console.WriteLine("Search and Load a profile");//not working yet
                    
                    bool done3 = false;
                    while (!done3)
                    {
                        userFilePath = "users.txt";
                        Console.WriteLine("Attempting to load the Default user database...");
                        
                        try//using a try catch block to handle if there is no file found
                        {
                            string[] lines = File.ReadAllLines(userFilePath);
                            foreach (string line in lines)
                            {
                                string[] index = line.Split(",");
                                User user = new User(index[0],index[1],float.Parse(index[2]),float.Parse(index[3]),bool.Parse(index[4]),bool.Parse(index[5]),bool.Parse(index[6]));
                                users.Add(user);//adding to our user list

                                
                            }
                            
                            newUser = User.FindProfile(users);//using a STATIC method here because I want the method to GIVE me and instance that doesn't yet exist.
                            //passing the users list to our method to find a person
                            //need to return the user file data here to populate a user

                            done3 = true;
                        }
                        catch (FileNotFoundException)//learned to use a try catch block to throw this exception
                        {
                            Console.WriteLine("The User file did not load or does not exist...please contact an administator");
                            done3 = false;//this will keep us in the loop until we write in a legit file.  
                            //I might want to add an option to escape out of this in case you don't know the main menu
                        }
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
                    Console.WriteLine("Delete your profile");//not working yet


                    break;//break fromcase 3
                    
                    case "6":
                    Console.WriteLine("Find A Shoe that Fits");//not working yet
                    break;//break fromcase 3
                    
                    case "7":
                    Console.WriteLine("View your recommended Shoe List");//not working yet
                    break;//break fromcase 3

                    case "8":
                    Console.WriteLine("4. Exit to main menu");//not working yet
                    exit1 = true;//allow us to exit the loop
                    Console.Clear();
                    break;//break from case 4 and exit the loop

                    
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
                Console.WriteLine("1. Add a shoe to the database");
                Console.WriteLine("2. Delete a shoe in the database");
                Console.WriteLine("3. Display shoes list");
                Console.WriteLine("4. Edit a shoe in the Database");
                Console.WriteLine("5. Load a Shoe File");
                Console.WriteLine("6. Save a Shoe File");
                Console.WriteLine("7. Load a User List");
                Console.WriteLine("8. Display the User List");
                Console.WriteLine("9. Save the User List");
                Console.WriteLine("0. Exit");
                input2 = Console.ReadLine();
                switch(input2)
                {
                    case "1"://functioning
                    Console.WriteLine("Add a shoe to the database");
                    Shoe newShoe = new Shoe();
                    newShoe.CreateShoe();
                    shoes.Add(newShoe);
                    //shoeData = true;
                
                    break;//break from case 1
                
                    
                    case "2"://functioning
                    Console.WriteLine("Delete a shoe in the database");
                    Console.WriteLine();
                    Console.WriteLine("Dispaying the Numbered Shoes List...");
                    Console.WriteLine();
                    int index1 = 1;
                    foreach (Shoe shoe in shoes)
                    {
                        Console.Write($"{index1}. ");
                        shoe.DisplayShoe();
                        index1++;
                    }
                    Console.WriteLine("Enter the number of the shoe you wish to remove");
                    int choice;
                    choice = int.Parse(Console.ReadLine());//NO logic here yet to control for wrong entries
                    shoes.RemoveAt(choice - 1);
                    Console.WriteLine($"Shoe number {choice} has been removed from the list.");

                    break;//break from case 3
                    
                    case "3"://functioning
                    Console.WriteLine("Dispaying the Numbered Shoes List...");
                    Console.WriteLine();
                    int index2 = 1;
                    foreach (Shoe shoe in shoes)
                    {
                        Console.Write($"{index2}. ");
                        shoe.DisplayShoe();
                        index2++;
                    }
                    break;//break from case 4
                    
                    case "4"://functioning
                    int index3 = 1;
                    Console.WriteLine("Edit a shoe in the Database");
                    Console.WriteLine("Displaying the Numbered Shoe List...");// need logic here to handle if database is empty?
                    
                  
                        foreach (Shoe shoe in shoes)
                        {
                
                            Console.Write($"{index3}. ");
                            shoe.DisplayShoe();
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
                         
                    
                       break;
                    
                    case "5"://functioning
                    
                    bool done1 = false;
                    while (!done1)
                    {
                        string file = "";
                        Console.WriteLine("Please enter a .txt file containg the shoe database: ");
                        file = Console.ReadLine();
                        try//learned about and decided to use a try catch block to handle if there is no file found
                        {
                            string[] lines = File.ReadAllLines(file);
                            foreach (string line in lines)
                            {
                                string[] index = line.Split(",");
                                Shoe shoe = new Shoe(index[0], index[1], float.Parse(index[2]), (index[3]), float.Parse(index[4]), float.Parse(index[5]), bool.Parse(index[6]), bool.Parse(index[7]), bool.Parse(index[8]));
                                shoes.Add(shoe);//adding to our shoe list
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
                    break;
                    
                    case "6"://functioning -- saving the shoe list to the shoe file
                    Console.WriteLine("Please enter a file name to save: ");
                    string fileName = Console.ReadLine();
                    
                    using(StreamWriter writer = new StreamWriter(fileName))//instantiating our streamwriter
                    {

                        foreach (Shoe shoe in shoes)//interate through our list of shoes to write each one to the path
                        {
                            writer.WriteLine(shoe.CreateShoeFileEntry());//calling our shoe file format method to write each one to the file
                            
                        }

                    }
                    break;

                    case "7":
                    bool done3 = false;
                    while (!done3)
                    {
                        string file = "";
                        Console.WriteLine("Please enter a .txt file containg the user database: ");
                        file = Console.ReadLine();
                        try//using a try catch block to handle if there is no file found
                        {
                            string[] lines = File.ReadAllLines(file);
                            foreach (string line in lines)
                            {
                                string[] index = line.Split(",");
                                User user = new User(index[0], index[1], float.Parse(index[2]), float.Parse(index[3]), bool.Parse(index[4]), bool.Parse(index[5]), bool.Parse(index[6]));
                                users.Add(user);//adding to our shoe list
                            }
                            done3 = true;
                        }
                        catch (FileNotFoundException)//learned to use a try catch block to throw this exception
                        {
                            Console.WriteLine("The File you have reqested does not exist");
                            done3 = false;//this will keep us in the loop until we write in a legit file.  
                            //I might want to add an option to escape out of this in case you don't know the main menu
                        }
                    }
                    break;

                    
                    
                    
                    

                    case "8":
                    Console.WriteLine("Displaying the user list...");
                    int i = 1;

                    foreach (User user in users)
                    {   
                        Console.Write($"{i}. ");
                        user.DisplayProfileLong();
                        i++;
                        
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
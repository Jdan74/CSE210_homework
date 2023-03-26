using System;
using System.IO;

class Program
{
   


    static void Main(string[] args)
    {
               
    //create our lists to hold the shoes and users
    List<Shoe> shoes = new List<Shoe>();
    //List<User> user = new List<User>();


    string input;
    bool exit = false;
    //bool shoeData = false;

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
                Console.WriteLine("Welcome to the user menu.  Please make a selection.");
                Console.WriteLine("1. Create a profile");
                Console.WriteLine("2. View your profile");
                Console.WriteLine("3. Delete your profile ");
                Console.WriteLine("4. Find A Shoe that Fits ");
                Console.WriteLine("5. Exit to main menu");
                input1 = Console.ReadLine();
                switch (input1)
                {
                    case "1":
                    Console.WriteLine("Create a profile");//not working yet
                    break;//break from case 1
                    
                    case "2":
                    Console.WriteLine("View your profile");//not working yet
                    break;//break from case 2
                    
                    case "3":
                    Console.WriteLine("Delete your profile");//not working yet
                    break;//break fromcase 3
                    
                    case "4":
                    Console.WriteLine("Find A Shoe that Fits");//not working yet
                    break;//break fromcase 3
                    
                    case "5":
                    Console.WriteLine("View your recommended Shoe List");//not working yet
                    break;//break fromcase 3

                    case "6":
                    Console.WriteLine("4. Exit to main menu");//not working yet
                    exit1 = true;//allow us to exit the loop
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
            while (exit2 == false)// a loop2 for this menu
            {
                Console.WriteLine("Welcome to the Admin menu.  Please make a selection.");
                Console.WriteLine("1. Add a shoe to the database");
                Console.WriteLine("2. Delete a shoe in the database");//not working yet
                Console.WriteLine("3. Display shoes list");
                Console.WriteLine("4. Edit a shoe in the Database");
                Console.WriteLine("5. Load a Shoe File");
                Console.WriteLine("6. Save a Shoe File");   
                Console.WriteLine("7. Exit");
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
                
                    
                    case "2"://non functioning
                    Console.WriteLine("Delete a shoe in the database");
                    break;//break from case 3
                    
                    case "3"://functioning
                    Console.WriteLine("Dispaying the Numbered Shoes List...");
                    Console.WriteLine();
                    int index1 = 1;
                    foreach (Shoe shoe in shoes)
                    {
                        Console.Write($"{index1}. ");
                        shoe.DisplayShoe();
                        index1++;
                    }
                    break;//break from case 4
                    
                    case "4"://functioning
                    int index2 = 1;
                    Console.WriteLine("Edit a shoe in the Database");
                    Console.WriteLine("Displaying the Numbered Shoe List...");// need logic here to handle if database is empty?
                    
                  
                        foreach (Shoe shoe in shoes)
                        {
                
                            Console.Write($"{index2}. ");
                            shoe.DisplayShoe();
                            index2++;
                        
                        }
                        bool done2 = false;
                        while (!done2)
                        {
                            Console.WriteLine("Enter the number of the shoe you wish to edit.");
                            string selectionString = Console.ReadLine();
                            //nt selectionInt;
                            if (int.TryParse(selectionString, out int selectionInt)  && selectionInt <= index2-1 && selectionInt !=0) // if the input is a number  and it is equal or less than the max index and it is not zero
                            {
                                Console.WriteLine("Selected Shoe: ");
                                //shoes[selectionInt - 1].DisplayShoe();
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
                                Shoe shoe = new Shoe(index[0], index[1], int.Parse(index[2]), int.Parse(index[3]), int.Parse(index[4]), int.Parse(index[5]), bool.Parse(index[6]), bool.Parse(index[7]), bool.Parse(index[8]));
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

                    case "7"://functioning 
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
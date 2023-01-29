public class Journal
{

    //MEMBER VARIABLES
    public string _filePath = "";//creating a member variable of type string to hold the file path
    //public string _filePath = "myjournal.txt";//creating a default file for the member variable of type string
    public List<Entry> _entries = new List<Entry>();//creating a new member variable of type Entry list and instantiating it so it exists to use.
    

    //CONSTRUCORS
    public Journal()
    {
    }

    //METHODS

    public void CreateJournalEntry()// a method that can be called on a journal class object to create a journal entry and store individual entries one at a time to a list
                                    
    {
        //Console.WriteLine("creating a Journal entry which is actualy a collection of individual journal entries.");
        Entry newEntry = new Entry();// instantiating a new entry so as to call the method to create a new entry
        newEntry.CreateEntry();
        newEntry.DisplayEntry();
        _entries.Add(newEntry);//adding the entries to the list.
        
    }

    public void DisplayUnsavedEntries()// a method to display ALL the entries stored in a _entries list variable of class Journal which have NOT YET been saved to the Journal file

{
    
    if (!_entries.Any())//ADDED a check to see if there is anything in our unsaved _entries list
    {
        Console.WriteLine("There are NO unsaved entries!");
        
    }
    else
    {
        foreach (var entry in _entries)
        {
            entry.DisplayEntry();
        }  
    }

}

    public void DisplayJournal()// a method to display an entire Journal from a text file, not just the _entries currently open
                                //this will need to read through a txt file line by line, create an array for each line, use a seperator
                                //value to assign each peice of the line to the proper Entry class member variable and display it all

    {

        if (_filePath == "")
        {
            Console.WriteLine("you have not opened a file. Name the file you would like to open: ");
            _filePath = Console.ReadLine();
        
            
            FileChecker();//calling the FileChecker method to handle incorrect files
            
                
                Console.WriteLine("your file Exists! Go ahead and start writing.");
                
        }
        else 
        {
            Console.WriteLine($"Displaying Journal file: {_filePath}");
            
        }
        
        List<string> lines = System.IO.File.ReadAllLines(_filePath).ToList();// this will read all the lines and send them to a list of variable called lines
        
        
        foreach (var line in lines)//loop through the lines one by one
        {
            //Console.WriteLine($"{line}");//this will write each line of the journal just as it is seen in the text file but we would rather use the code below to extract each part
            string[] entries = line.Split("~");//this will create a string array called entries to hold the line and split it at the seperator
            Entry newEntry = new Entry();//we have to create a new object of type Entry to hold each member variable as we iterate through
            newEntry._entryDate = entries[0];
            newEntry._entryPrompt = entries[1];
            newEntry._entryResponse = entries[2];
            Console.WriteLine($"Date: {newEntry._entryDate}, Prompt: {newEntry._entryPrompt} Response: {newEntry._entryResponse}, ");
            
        }
    }

    public void LoadJournal()// a method to load a text file by designating the _filePath
    {
        Console.WriteLine("What file would you like to open? ");

        _filePath = Console.ReadLine();

        FileChecker();//runing my FileChecker method to make sure there is a file to open that exists
        

    }

    public void SaveJournal()// a method to go through unsaved _entries and append these to the text file one by one
    {
        if (_filePath == "")//if we have not get loaded or designated a filepath...
        {
            Console.WriteLine("There is no open file. What would you like to name your file? ");
            _filePath = Console.ReadLine();

        }
        else
        {
            Console.WriteLine($"You are saving to the file called {_filePath}");
        }

        foreach (var entry in _entries)//loop through the lines in the _entries list
        {
            using (StreamWriter sw = File.AppendText(_filePath))//use StreamWriter to add each line as a new entry to the designated file
            {
                 sw.WriteLine($"{entry._entryDate}~{entry._entryPrompt}~{entry._entryResponse}");// we'll use a ~ to seperate the data variables
            }   
        }
        _entries.Clear(); //clearing out the list so it is empty AFTER it is saved to the file.  
                            //This will prevent duplicates from being added to our file

    }
   
    public void FileChecker()
    {

        bool fileExist = File.Exists(_filePath);//using a bool set to TRUE if the _filePath exists
            
        
            while(!fileExist)// a while loop to keep going until an existing file is opened or user has elected to return to main menu
            {
                string input = "";
                Console.WriteLine("File you entered DOES NOT EXIST!");
                Console.WriteLine("Press '1' to return to the main menu and use SAVE option to create a new file");
                Console.WriteLine("or, Press any other key to reenter a file name you would like to open");
                input = Console.ReadLine();               
                

               if (input == "1")// an if statment to select the option of user
                {
                break;// this will send user back out to main menu
                }
                else//ask user for a file name again.
                {    
                Console.WriteLine("Name the file you would like to open:");
                _filePath = Console.ReadLine();
                fileExist = File.Exists(_filePath);
                }
            }
            
            Console.WriteLine("your file Exists! Go ahead and start writing.");
    }

}
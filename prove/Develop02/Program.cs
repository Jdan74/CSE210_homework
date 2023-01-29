using System;
using System.IO; //needed so C# knows where to find StreamWriter Class
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;//required to use the List Class


class Program
{
    static void Main(string[] args)
    {
        
        //create while loop to bring you back to menu until quit is selected
        //create a variable to hold selection

        string input = "";// a variable to hold the selection we make for the choices
                    
        Console.WriteLine("Welcome to the Journal Program!");
    

        Journal newJournal = new Journal(); //instantiate a new object variable called newJournal of the class type Journal to hold the journal object we are manipulating.  

        while (input != "6")
        {
            
            Console.WriteLine("Please make a selection.");
            Console.WriteLine("1. Write New Entry");
            Console.WriteLine("2. Display New Entries");
            Console.WriteLine("3. Load Journal");
            Console.WriteLine("4. Save Journal");
            Console.WriteLine("5. Display Entire Journal ");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            input = Console.ReadLine(); //getting our choice from the terminal
                    
            if (input == "1")
            {                  
                newJournal.CreateJournalEntry(); 
            }
            else if (input == "2")
            {
                newJournal.DisplayUnsavedEntries();
            }
            else if (input == "3")
            {
                newJournal.LoadJournal();
            }
            else if (input == "4")
            {     
                newJournal.SaveJournal();
            }
            else if (input == "5")
            {
                Console.WriteLine("Displaying entire Journal.");
                newJournal.DisplayJournal();
            }
            else if (input == "6")
            {
                Console.WriteLine("Exiting Journal Program...");
            }
            
            else
            {
                Console.WriteLine("Ivalid entry! Please enter a proper selection 1-6");
            }

       }

        


    }
}
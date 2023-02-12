using System;


//I improved on this program by adding the option and ability to unhide words, or bring them back in case you hide too many.
//I also added code to let you know when all the words are again visible and logic to prevent from crashing
//I also added some code to account for handeling entering incorrect options such as mixed cases.


class Program
{
    static void Main(string[] args)
    {

        //creating our scripture using the constructor and passing the reference and the text values
        Scripture scripture = new Scripture(new Reference("Mosiah", "2", "17"),"And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.");
        scripture.DisplayWholeScripture();//display the scripture
        Console.WriteLine();//add blank line
        string selection;//Console.ReadLine();

        do 
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue, type 'unhide' to reveal words, type 'quit' to finish");
            selection = Console.ReadLine().ToLower();//read line and make all letters lower case
        
            if (selection == "")
            {
                scripture.HideWords();
                scripture.HideWords();
                scripture.HideWords();
                scripture.DisplayWholeScripture();
                if (scripture.IsCompletelyHidden() == true)//run this to see if all the words are hidden and if so break out and end program
                {
                    break;
                }
                Console.WriteLine();
            }
            else if (selection == "unhide")
             {
                scripture.UnHideWords();
                scripture.UnHideWords();
                scripture.UnHideWords();
                scripture.DisplayWholeScripture();
                if (scripture.IsCompletelyHidden() == true)//run this to see if all the words are hidden and if so break out and end program
                {
                    break;
                }
                else if (scripture.IsCompletelySeen() == true)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("All the Words are Visible!");
                   
                }
                Console.WriteLine();
            }
            else if(selection == "quit")
            {
                break;
            }
            else
            {
                Console.WriteLine("you have made an incorrect selection, please try again, press Enter to continue or type quit to exit");
                selection = Console.ReadLine();
            }
        }while (selection != "quit");
    }
}
using System;

//Extra things I did for this assignment.  I added additional options to reset a goal, delete all goals, and clear your score.  I also add code to handle cases 
//where you are trying to record a goal that you have already completed which will tell you the goal is completed, then give you the option to reset the goal.
//some additional code was added to prevent crashes in case of incorrect entries, etc.  

class Program
{
    static void Main(string[] args)
    
    {       
        string choice = "";
        int totalPoints = 0;//to keep track of total points.  we'll save this as index 0 of our list
        List<Goal> listOfGoals = new List<Goal>();//instantiating a new list of Goal type to populate 
        Console.Clear();
    

        while (choice != "9")
        {
        Console.WriteLine();
        Console.WriteLine($"You have earned {totalPoints} points.");
        Console.WriteLine();    

        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Reset a Goal");
        Console.WriteLine("  7. Delete all Goals");
        Console.WriteLine("  8. Clear Score");
        Console.WriteLine("  9. Quit"); 
        Console.WriteLine("Select a choice from the menu: ");
        choice = Console.ReadLine();
        
        if (choice == "1")//create new goal
        {
            string choice1 = "";

            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");  
            Console.WriteLine("  3. Checklist Goal");
            Console.WriteLine("Which type of goal would you like to create? ");
            choice1 = Console.ReadLine();
            
            //while (choice1 == "1" || choice1 == "2" || choice1 == "3")//stay in loop until proper selection made, give error if other entry made
            //{
            
            if (choice1 == "1")// creat a simple goal entry and add it to our list
            {
            SimpleGoal simpleGoal = new SimpleGoal();//instantiating a new simple goal
            simpleGoal.CreateGoalEntry();// calling our parent class method as this should work to get the parts we need for this simple goal
            listOfGoals.Add(simpleGoal);

            }
            
            else if (choice1 == "2") //eternal goal
            {
            EternalGoal eternalGoal = new EternalGoal();//instantiating a new eternal goal
            eternalGoal.CreateGoalEntry();
            listOfGoals.Add(eternalGoal);

            }
            
            else if (choice1 == "3")//checklist goal
            {
                ChecklistGoal checklistGoal = new ChecklistGoal();//instantiating a new checklist goal
                checklistGoal.CreateGoalEntry();
                listOfGoals.Add(checklistGoal);
            }
            
            else
            {
                Console.WriteLine("You have made an invalid entry, please choose an option 1-3");
            }

        }
        else if (choice == "2")// List Goals - this will iterate through the instantiated list, and call a polymorphic method to display each goal to the screen.  
        {                      
            ;
            //string completedValue = "";
            
            Console.WriteLine("The goals are: ");
            int i = 0;//a variable to hold the index number
            foreach (var goal in listOfGoals)//iterate through our list...
            {
                Console.WriteLine($"{i+1}.{goal.DisplayStatus()} {goal.DisplayGoal()}");// and for each item add we'll number them and then call the DIsplayGoal method on each one
                i++;//increase each time through the loop
            }
            
        }
        else if (choice == "3")//Save goals - ask for a file name.  This will save both the total points and then the list of goals to a text file
        {                       //we could use a polymorphic method to write each goal to the text file in different ways.
                                //will need to write total points to first line.
                                //could simply overwrite the text file that exists as it will have all goals and need to update the points as well

            Console.WriteLine("File Name:?");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))//instantiating a StreamWriter object to use
            {
                foreach (Goal goal in listOfGoals)//iterate through the list
                {
                    writer.WriteLine(goal.WriteGoalToFileFormat());//call the methode to write to text file format for each line and type
                }
                writer.WriteLine(totalPoints);//we'll add our total points earned to the last line of the text doc
            }
        }
        else if (choice == "4")//load goals - this will iterate through the text file, assign the first line to total points
                                
        {                             //then break apart the lines by commas and assign each part to a field
                                        // thenn we'll use the first field, the name of the class, and a series of if statements
                                        //to call the specific parentclass.add(new childclass(name, description, points)) on the goal type
                                        //this is will repopulate our goals list from the text file.  Then later when writing back to the 
                                        //text file we can simply overwrite the last one, might require clearing and then rewriting it
            
            Console.WriteLine("What is the file name you would like to open? ");
            string fileName = Console.ReadLine();
            string[] lines = File.ReadAllLines(fileName);//creating an array to hold the entire text file
            
            foreach (string line in lines)//go through our entire list line by line
            {
                string[] index = line.Split(",");//first we'll split each line up based on the comma
                string classType = index[0];
                
                if (classType == "SimpleGoal:")//if statements to determin which class type needs to be called to repop the list and call the speci
                {
                    SimpleGoal newGoal = new SimpleGoal(index[1],index[2],int.Parse(index[3]),bool.Parse(index[4]));
                    listOfGoals.Add(newGoal);
                }
                else if (classType == "EternalGoal:")//if a list goal type
                {
                    EternalGoal newGoal = new EternalGoal(index[1],index[2],int.Parse(index[3]),bool.Parse(index[4]));
                    listOfGoals.Add(newGoal);
                }
                else if (classType == "ChecklistGoal:") //if an eternal goal
                {
                    ChecklistGoal newGoal = new ChecklistGoal(index[1],index[2],int.Parse(index[3]),bool.Parse(index[4]),int.Parse(index[5]),int.Parse(index[6]),int.Parse(index[7]));
                    listOfGoals.Add(newGoal);
                }
                else//this would be the only case not used above and should represent our last line or total points
                {
                    totalPoints = int.Parse(line);//assign the last line as our totalPoints variable
                }
            }
            
        } 
        else if (choice == "5")//record Event - iterate through the list, skipping the first (total points), 
        {                       //this will call a polymorphic method to create add points to the total based on the goal selected
                    //totalPoints = totalPoints + goal.DisplayPointValue();//add the point value of the activity to our totalpoints variable
            Console.WriteLine("The Goals are:");
            int i = 0;
            foreach (Goal goal in listOfGoals)//writing our list one by one
            {
                Console.WriteLine($"{i+1}. {goal.GetName()}");// and for each item add we'll number them and then call the GetName() method on each one
                i++;//increase each time through the loop
            }
            Console.WriteLine("Which goal did you accomplish? ");
            string goalChoiceString = Console.ReadLine();//get a choice from the user
            int goalChoiceInt = int.Parse(goalChoiceString);// parse to an int and save as varibale
            listOfGoals[goalChoiceInt - 1].CheckStatusAndUpdate();
            int newPoints = listOfGoals[goalChoiceInt -1].GiveAndShowPoints();
            totalPoints = totalPoints + newPoints; //update our total points
            Console.WriteLine($"You now have {totalPoints} points ");//display the total points
        }
        else if (choice == "6")//reset a goal
        {
            Console.WriteLine("Which would you like to reset?");
            int goalSelection = int.Parse(Console.ReadLine());
            listOfGoals[goalSelection - 1].ResetGoal();
        }
        else if (choice == "7")//delete all goals
        {
            Console.WriteLine ("you have elected to DELETE ALL GOALS...are you sure? press y for YES or another other key for NO");
            string selection = Console.ReadLine();
            if (selection.ToLower() == "y")
            {
                Console.WriteLine("Clearing the list!!!...");
                listOfGoals.Clear();
            }
            else
            {
                Console.WriteLine("List will remain the same...");
            }
            
        }         
        else if (choice == "8")//clear the score
        {
            Console.WriteLine("You have chosen to clear your score...are you sure? press y for YES or any other key for NO");
            string selection = Console.ReadLine();
            if (selection.ToLower() == "y")
            {
                Console.WriteLine("Clearing the score!!!...");
                totalPoints = 0;
            }
            else
            {
                Console.WriteLine("Score will remain the same...");
            }
        }     
        else if (choice == "9")//exit
        {
            Console.WriteLine(" you have chosen to exit...good by");
        }
        else 
        {
            Console.WriteLine("You have made an invalid entry, please enter a number 1-8");
        }
        }
        Console.WriteLine("exiting program....");

    }
}
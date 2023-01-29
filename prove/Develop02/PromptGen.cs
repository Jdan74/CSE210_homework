public class PromptGen // a Class to generate a prompt
{
    //Member Variables

    public string _randomPrompt = "";//adding static so this variable is acessible outside an instance?
    
    public List<string> prompts = new List<string>();


     // Constructors 
    
        public PromptGen()// I learned that you can put things inside the constructor so they are done automatically with instantiation.
           {
            prompts.Add("What was the best thing that happend to you today?");//populating the list in the constructor so they are only generated once
            prompts.Add("How did you listen to the Lord today?");
            prompts.Add("What would you have liked to have done differently today?");
            prompts.Add("Who did you help today?");
            prompts.Add("What was the weather like today?");
        }

        // Methods 
        
        public void DisplayRandomPrompt()//this method will generate a random prompt from the list generated in the constructor
        {
            
            Random rnd = new Random();//instantiating a variable called rnd of Class Random using the Random() constructor
            int randomNumber = rnd.Next(0, 5);//using the random.Next method to limit the random number between 0 and 4
            _randomPrompt = prompts[randomNumber];//assigning the random prompt to the member variable
            Console.WriteLine($"{_randomPrompt}"); // printing a random index (0-4) from our list of prompts using the Random Class method
            Console.Write("  >  ");


        }

        








}
public class Entry
{


//Member Variables
public string _entryDate = "";
public string _entryPrompt = "";
public string _entryResponse = "";

//Constructors

public Entry()
{
}

//Methods

public void CreateEntry()// a method that can be called to create a single entry
{
    
    PromptGen prompt = new PromptGen();//instantiating a new prompt of this class
        
        prompt.DisplayRandomPrompt();//calling this method to generate the prompt for the user and display it on the console
        
        DateTime today = DateTime.Today;//creating today's date as variable useing the DateTime class and today method
        
        _entryDate = today.ToString("d");//converting the date to a string in the format that we want using a string conversion method of the date class and setting it equal to the member variable _date  
        _entryPrompt = prompt._randomPrompt;//setting the prompt from prompt generator = to the member variable of Entry class
        _entryResponse = Console.ReadLine();// getting the text written from the user and assigning it to the member variable _response

}

public void DisplayEntry()// a method to display a single entry of date, prompt, and response.
{
    //Console.WriteLine("Displaying your entry");
    Console.WriteLine($"{_entryDate} {_entryPrompt} {_entryResponse} ");
}

}
class Scripture//
{
//Member Variables--------------------------------------------------------------------------------
private Reference _reference;// = new Reference();//variable to hold the reference instance.  Had to make a generic constructor to get this to work
private string _text;//variable to hold the text to memorize
private List<Word> _words;// = new List<Word>();//creating a list of types Word to hold each word of the 
                                            //memorization text and whether it should be shown or hidden 
                                            //AND INSTANTIATING IT at the same time

//Constructors-----------------------------------------------------------------------------------------

public Scripture (Reference reference, string text)
{
    _text = text;
    _words = new List<Word>();
    _reference = reference;

    List<string> wordList = text.Split(" ").ToList();//convert or long string into a list of string.
    
    foreach (string var in wordList)//instantiate each word of the list to a type Word so we can later show or hide them. Default is show
    {   
        Word newWord = new Word(var);//calling our word class constructor to convert each string to a Word type in our. Now we can decided if should be shown or hidden
        _words.Add(newWord);//then adding each new Word instance to our _words list
        
    }
}
//getters and setters----------------------------------------------------------------------------------

public List<Word> GetWords()//this getter will just return the list<Word> object
{
    return _words;
}


//Methods-----------------------------------------------------------------------------------

public void DisplayWordObjectAsString()//could make this return a string instead of void, but works either way
                                        //this will iterate through the list of words holding our scripture
                                        //and call the DisplayWord() method on each one and write to console
{
   Console.Write(" ");
   foreach (Word var in GetWords())//this will iterate through each word in the list of words using the getter
        {
            Console.Write(var.DisplayWord());//sending the word to the console
            Console.Write(" ");//adding some spaces back to the text
        }
 }
public void DisplayWholeScripture()// a method to display the scripture, called at beginning of program.
{
    Console.Write(_reference.DisplayReference());//using our DisplayReference() method here to show the reference
    Console.Write(" ");
    DisplayWordObjectAsString();
}
public void HideWords()// a method to select a random word in the list and set the Word class bool hide value to true
{
    int listSize = _words.Count();//get the size of list and set to a local variable.
    Random rnd = new Random();//instantiate a random number class variable
    int randomNumber = rnd.Next(0, listSize);//using the random.Next method to limit the random number between 0 and the list size
    bool updated = false;
    while (updated == false)
    {
        if (_words[randomNumber].GetWordBool() == false)
        {
            _words[randomNumber].SetWordBool(hide:true);//using a setter instead of a method of class Word
            updated = true;
        }
        else 
        {
            randomNumber = rnd.Next(0, listSize);//get a new random number and check it again
        }
    }
}
public bool? IsCompletelyHidden()// a method to return a bool to show if all the words are hidden
{
    bool? allHidden = null;//using a bool set to null 
    int counter = 0;// a variable to hold the number of shown words still remain
    {
        foreach (Word var in GetWords())//this didn't work until I changed _words to GetWords() as this will 
                                    //get each word object
        {
            if (var.GetWordBool() == false)
            {
                counter = +1;//adds 1 to the counter if a word Not hidden.  True would indicate the workd is hidden.
            }
        }
        if (counter == 0)
        {
            //Console.WriteLine("all ARE hidden");
            allHidden = true;
        }
        else
        {
            //Console.WriteLine("all are Not hidden");
            allHidden  = false;
        }
    }
    return allHidden;
}
public bool? IsCompletelySeen()//a method to return a bool to show if all the words are visiable
{
    bool? allSeen = null;//using a bool set to null 
    int counter = 0;// a variable to hold the number of shown words still remain

    {
        foreach (Word var in GetWords())//using GetWords() get each word intance
        {
            if (var.GetWordBool() == true)//if bool is true
            {
                counter = +1;//adds 1 to the counter if a word Not hidden.  True would indicate the workd is hidden.
            }
        }

        if (counter == 0)//if there are No hidden words, counter will be 0
        {
            allSeen = true;
        }
        else
        {
            allSeen  = false;
        }
    }
    return allSeen;
}
public void UnHideWords()
{
    
    int listSize = _words.Count();//get the size of list and set to a local variable.
    Random rnd = new Random();//instantiate a random number class variable
    int randomNumber = rnd.Next(0, listSize);//using the random.Next method to limit the random number between 0 and the list size
    bool updated = false;

    while (updated == false && IsCompletelySeen() == false)
    {
        if (_words[randomNumber].GetWordBool() == true)
        {
            _words[randomNumber].SetWordBool(hide:false);//using a setter instead of a method of class Word
            updated = true;
        }
        else 
        {
            randomNumber = rnd.Next(0, listSize);//get a new random number and check it again
        }

    }
}
}
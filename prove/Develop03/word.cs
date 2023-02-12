class Word // purpose of this class is to hold the text of a word and also a value of being hiddin or hidden

{
    //member variables-------------------------------------------------------------------------------
    private string _word;//will need a getter and setter for this to hide
    private bool _hide;// a bool to hold the status of the word.  Will need a getter and setter for this variable as it will need to be changed 
    
    //constructors----------------------------------------------------------------------------------
    public Word(string text)//constructor to accept one string as a word and set default hide to false
    {
        _word = text;
        _hide = false;
    }
    
    //getters and setters --------------------------------------------------------------------------

    public string GetWord()
    {
        return _word;
    }

    public bool GetWordBool()
    {
        return _hide;
    }

    public void SetWordBool(bool hide)
    {
        _hide = hide;
    }

    //methods-------------------------------------------------------------------------------------

    public string DisplayWord()//string word, bool hide)
    {
        int letterCount = GetWord().Count();//find number of characters and set = to letterCount
        string text;

        if (GetWordBool() == false)// if the bool of the word is false, meaning the word is not hidden
        {   
            text = GetWord();//set the text variable to that word
        }
        else 
            text = String.Concat(Enumerable.Repeat("_",letterCount));//this will set the word to "____" based on the number of chars in the original word

        return text;
    }
}

class Reference //this is a class to hold the reference to the scripture we are using in our memorization program
{

//member variables
private string _book;
private string _chapterNum;
private string _verseNumFirst;
private string _verseNumLast;

// constructors--------------------------------------------------------------------------------------------
// 3 constructors, and generic and 2 others to handle both cases of a single scripture reference and 2 numbers to represent a span

public Reference ()//having one generic constructor that takes not parameters may be necessary so as to be able
                     // to instantiate this as a member variable of another close without requiring immediate paramaters
{   
}

public Reference (string book, string chapterNum, string verseNum)// a constructor that will take one verse
{
_book = book;
_chapterNum = chapterNum;
_verseNumFirst = verseNum;
_verseNumLast = "";//to leave this empty if only one verse is referenced
}

public Reference (string book, string chapterNum, string verseNum1, string verseNum2) // a constructor that will take a span of verses
{
_book = book;
_chapterNum = chapterNum;
_verseNumFirst = verseNum1;
_verseNumLast = ($"-{verseNum2}");// to place the dash and second number if a range
}

//getters and setters -------------------------------------------------------------------
//none needed as the variables are all populated through the constructors

//Methods-------------------------------------------------------------------------------------------
public string DisplayReference()// a method to dislay the scripture.
{
    string text = ($"{_book} {_chapterNum}:{_verseNumFirst}{_verseNumLast}");
    return text;//send the text back to where it was called from
}

}
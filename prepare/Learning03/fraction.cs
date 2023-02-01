public class Fraction
{

//member variables
private int _top;
private int _bottom;



// constructors//remember that return types are left EMPTY on constructors
public Fraction()
{
}


public Fraction(int wholeNumber)// requires a whole number
{

   _top = wholeNumber;
   _bottom = 1;

}
public Fraction(int top, int bottom)//requires a numerator and a denominator
{

    _top = top;
    _bottom = bottom;

}

//getters and setters = special methods specific to a class to allow other classes to set and get 
//the variable values without actually seeing or working direction with the class member variables.
//THESE need return types, just like class methods.
public int GetTop()//public so accessible, returns an int of the value of _top variable
{
    return _top;
}
public void SetTop(int top)//public so accessible, void as returns nothong, accepts one int and sets the value of the _top variable, 
{
    _top =  top;
}
public int GetBottom()//public so accessible, returns an int from the _bottom variable
{
    return _bottom;
}

public void SetBottom(int bottom)//public so it's accessible, returns nothing, accepts one int called bottom and sets it to _bottom
{
 _bottom = bottom;
}



//methods

public void GetFractionString()
{

Console.WriteLine($"{_top}/{_bottom}");

}

public void GetDecimalValue()// (https://stackoverflow.com/questions/1043164/why-does-decimal-divideint-int-work-but-not-int-int - int is an integer type; dividing two ints performs an 
//integer division, i.e. the fractional part is truncated since it can't be stored in the result type 
//(also int!). Decimal, by contrast, has got a fractional part. By invoking Decimal.Divide, your int arguments
// get implicitly converted to Decimals. You can enforce non-integer division on int arguments by explicitly 
//casting at least one of the arguments to a floating-point type, e.g.:)

{
    double result = (double) _top / _bottom;
    Console.WriteLine(result);
    
    //Console.WriteLine(Decimal.Divide(_top,_bottom)); This method also works
}


}
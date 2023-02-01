public class Fraction
{

//member variables
private int _top;
private int _bottom;



// constructors//remember that return types are left EMPTY on constructors
public Fraction()
{
    _top = 1;
    _bottom =1;
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



//methods -- I had to Correct this as I initially was returning nothing and relying on the method to print to console but this was incorrect as they are to return a string and a double only

public string GetFractionString()

{
    string text = ($"{_top}/{_bottom}");
    return text;
}

public double GetDecimalValue()// 

{
    double result = (double) _top / _bottom;
    return result;
    
    //(Decimal.Divide(_top,_bottom)); This method also works
}


}
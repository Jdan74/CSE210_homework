class Rectangle : Shape//we'll inherit from Shape class
{
//member variables___________________________________________________________________

private double _length = 0;//length variable
private double _width = 0;//width variable

//Constructors_________________________________________________________________________

    public Rectangle(string color, double length, double width) : base (color)//calling our base class color parameter
    {
        _length = length;
        _width = width;
    }
    
//getters and setters______________________________________________________________________________
   

//Methods______________________________________________________________________

   public override double GetArea()//using the override feature of polymorphism 
   {
    return _width * _length;//returning the length x 4 for Rectangle
   }

}
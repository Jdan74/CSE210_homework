class Square : Shape//we'll inherit from Shape class
{
//member variables___________________________________________________________________

private double _side = 0;

//Constructors_________________________________________________________________________

    public Square(string color, double side) : base (color)//passing our color parameter to the base class
    {
        _side = side;
    }
    
//getters and setters______________________________________________________________________________
   

//Methods______________________________________________________________________

   public override double GetArea()//using the override feature of polymorphism 
   {
    return _side * _side;//returning the area of square
   }

}
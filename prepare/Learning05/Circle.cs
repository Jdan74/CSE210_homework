class Circle : Shape//we'll inherit from Shape class
{
//member variables___________________________________________________________________

private double _radius = 0;//radius variable

//Constructors_________________________________________________________________________

    public Circle(string color, double radius) : base (color)
    {
        _radius = radius;
    }
    
//getters and setters______________________________________________________________________________
   

//Methods______________________________________________________________________

   public override double GetArea()//using the override feature of polymorphism 
   {
    return _radius * _radius * 3.14;//returning are of Circle
   }

}
class Shape
{
//member variables___________________________________________________________________

private string _color = "";    

//Constructors_________________________________________________________________________


    public Shape()
    {
    }
    public Shape(string color)
    {
        _color = color;
    }
    
//getters and setters______________________________________________________________________________


    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }
    

//Methods______________________________________________________________________

   public virtual double GetArea()
   {
    return 1;
   }
    

}
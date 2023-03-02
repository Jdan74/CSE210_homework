using System;

class Program
{
    static void Main(string[] args)
    {
       
       List<Shape> shapeList = new List<Shape>();
        shapeList.Add(new Square("blue", 5));
        shapeList.Add(new Rectangle("red", 10, 3));
        shapeList.Add(new Circle("yellow", 3));

        foreach (Shape shape in shapeList)
        {
            Console.WriteLine($"the color of the {shape.GetType()} is {shape.GetColor()} and the area is {shape.GetArea()}");
        }  //used the .GetType() method to show me the child class name as well....sweet.  This is so fun!
    }
}
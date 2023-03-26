
class Shoe
{
    //member variables___________________________________________________________________
    private string _brand;
    private string _model;
    private int _size;
    private int _width;

    private int _lengthMeasured;
    private int _widthMeasured;
    private bool _pathFlatFoot;
    private bool _pathHeelPain;
   private bool _pathHammerToe;


//Constructors_________________________________________________________________________

    public Shoe()
    {
    }
    public Shoe(string brand, string model, int size, int width, int lengthMeasured, int widthMeasured, bool pathFlatFoot, bool pathHeelPain, bool pathHammerToe)
    {
        _brand = brand;
        _model = model;
        _size = size;
        _width = width;
        _lengthMeasured = lengthMeasured;
        _widthMeasured = widthMeasured;
        _pathFlatFoot = pathFlatFoot;
        _pathHeelPain = pathHeelPain;
        _pathHammerToe = pathHammerToe;

    }
    
//properties and getters and setters - I read about and decided to try using properties insead of explicit getters and setters to make this easier______________________________________________________________________________
//not sure if I'll really need this much though if I keep things flowing through the methods as much as possible
    public string Brand {get; set;}// this is using the short hand auto-implemented getters and setters method. This method will automatically create the getters and setters knowing the the underscore and first letters and the only things changed
    public string Model {get; set;}
    public int Size {get; set;}
    public int Width {get; set;}
    public int LengthMeasured {get; set;}
    public int WidthMeasured {get; set;}
    public bool PathHammerToe {get; set;}
    public bool PathHeelPain {get; set;}
    public bool PathFlatFoot {get; set;}


    // public string GetbrandName()//may not need this
    // {
    //     return _brandName;//can't return this unless to string
    // }
    // public void SetSeconds(int seconds)//will need this
    // {
    //     _seconds = seconds;
    // }
    //  public string GetShoeName()//may not need this
    // {
    //      return _ShoeName;
    //  }
    //  public void SetAcivityName(string ShoeName)//may not need this
    //  {
    //      _ShoeName = ShoeName;
    //      return _seconds.ToString();//can't return this unless to string
    // }

//Methods______________________________________________________________________

public void DisplayShoe()
{
    Console.WriteLine(($"Brand: {_brand}, Model: {_model}, Size: {_size}, Width: {_width}, Measured Length: {_lengthMeasured}, Measured Width: {_widthMeasured}, FlatFoot approved: {_pathFlatFoot}, Heel Pain approved: {_pathHeelPain}, Hammertoe approved: {_pathHammerToe} "));
}

public void CreateShoe()
{
    //Shoe shoe = new Shoe();// new shoe

    Console.WriteLine("Brand:");
    _brand = Console.ReadLine();
    Console.WriteLine("Model:");
    _model = Console.ReadLine();
    Console.WriteLine("Size:");    
    _size = int.Parse(Console.ReadLine());
    Console.WriteLine("Width:");
    _width = int.Parse(Console.ReadLine());
    Console.WriteLine("Measured Length:");
    _lengthMeasured = int.Parse(Console.ReadLine());
    Console.WriteLine("Measured Width:");
    _widthMeasured = int.Parse(Console.ReadLine());
    Console.WriteLine("Flat Foot Approved? Enter y for yes or any other key for no");
    string answer1 = Console.ReadLine().ToLower();
        if (answer1 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
        {
            _pathFlatFoot = true;
        }
        
    Console.WriteLine("Heel Pain Approved? Enter y for yes or any other key for no");
    string answer2 = Console.ReadLine().ToLower();
        if (answer2 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
        {
            _pathHeelPain = true;
        }
            
    Console.WriteLine("Hammer Toe Approved? Enter y for yes or any other key for no");
    string answer3 = Console.ReadLine().ToLower();
        if (answer3 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
        {
            _pathHammerToe = true;
        }

        

    //return shoe;
}
public string CreateShoeFileEntry()
{
    return  $"{_brand},{_model},{_size},{_width},{_lengthMeasured},{_widthMeasured},{_pathFlatFoot},{_pathHeelPain},{_pathHammerToe}";
}
public void EditShoe()
{
        //Console.Clear();
        bool done = false;
        string newEntry = "";
        
        while (done == false)
        {
            
            Console.WriteLine($"1. Brand: {_brand}");//could use the properties instead
            Console.WriteLine($"2. Model: {_model}");
            Console.WriteLine($"3. Size: {_size}");
            Console.WriteLine($"4. Width: {_width}");
            Console.WriteLine($"5. Measured Length: {_lengthMeasured}");
            Console.WriteLine($"6. Measured Width: {_widthMeasured}");
            Console.WriteLine($"7. Flat Foot approved: {_pathFlatFoot}");
            Console.WriteLine($"8. Heel Pain approved: {_pathHeelPain}");
            Console.WriteLine($"9. Hammertoe approved: {_pathHammerToe}");

            Console.WriteLine("Enter the number of the item you wish to edit.");
            string selectionString = Console.ReadLine();
            
            int selectionInt;
        
            
            bool done3 = false;
            while (!done3)
            {
                    
                    if (int.TryParse(selectionString, out selectionInt)  && selectionInt >=1 && selectionInt <= 9)// try to parse to an int, and if it is, go ahead and output the value
                    {
                        Console.WriteLine($"Enter the new {ShoePropertiesIndex(selectionInt)} : ");
                        newEntry = Console.ReadLine();//could be a string or an int so we'll use object, BUT we'll need to cast it back to whatever it needs to be before storing it
                        done3 = true;
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine("You have made an ivalid entry, try again");
                        done3 = false;
                    }
                   
                    

            }

                         
           switch (selectionString) 
           {
                case "1":
                {
                    _brand = newEntry;
                }
                break;

                case "2":
                {
                    _model = newEntry;
                }
                break;

                case "3":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        int number;

                        if (int.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _size = number;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter a number Please Try Again: ");
                            newEntry = Console.ReadLine();

                        }
                    }
                }
                break;

                case "4":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        int number;

                        if (int.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _width = number;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter a number Please Try Again: ");
                            newEntry = Console.ReadLine();
                            
                        }
                    }
                }
                break;

                case "5":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        int number;

                        if (int.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _lengthMeasured = number;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter a number Please Try Again: ");
                            newEntry = Console.ReadLine();
                            
                        }
                    }
                
                }
                break;
                 case "6":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        int number;

                        if (int.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _widthMeasured = number;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter a number Please Try Again: ");
                            newEntry = Console.ReadLine();
                            
                        }
                    }
                
                }
                break;
                case "7":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        bool result;

                        if (bool.TryParse(newEntry, out result))//using a tryParse to send an error option if bool is not correctly interpreted
                        {
                            _pathFlatFoot = result;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter True or False! Please Try Again: ");
                            newEntry = Console.ReadLine();
                            
                        }
                    }
                    
                }
                break;

                case "8":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        bool result;

                        if (bool.TryParse(newEntry, out result))//using a tryParse to send an error option if bool is not correctly interpreted
                        {
                            _pathHeelPain = result;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter True or False! Please Try Again: ");
                            newEntry = Console.ReadLine();
                            
                        }
                    }
                }
                break;

                case "9":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        bool result;

                        if (bool.TryParse(newEntry, out result))//using a tryParse to send an error option if bool is not correctly interpreted
                        {
                            _pathHammerToe = result;//parsing is successful
                            allDone = true;
                        }
                        else
                        {
                            Console.WriteLine("you must enter True or False! Please Try Again: ");
                            newEntry = Console.ReadLine();
                        }
                    }                    
                }
                break;
            
                default:
                Console.WriteLine("You have made an invalid entry, please try again.");
                continue;
           }

            // else//if can't parse sectionInt to an int, should display this message and keep in the while loop
            // {
            //     Console.WriteLine("You have made an invalid entry, please make a selection from 1-8");//this then runs in a loop and needs to be fixed
            //     selectionInt = 0;
            //     done = false;

            // }
        
            Console.WriteLine("Edits have been saved.  Here's the updated shoe: ");
            //Console.Clear();
            DisplayShoe();
            //Console.WriteLine();
            Console.WriteLine("Press 'Q' to quit or any other key to edit another item");
            string response = Console.ReadLine();
             
            if (response.ToLower() == "q")
            {
                done = true;
            }
           
            else 
            {
                done = false;
            }
            
        }

}


    private object ShoePropertiesIndex(int index)// a method to hold and array and return the name of the property when given an index
    {
        
        object[] shoePropertiesArray = new object[9];  //creating an array of objects to refence our variabes by number
        shoePropertiesArray[0]= "Brand";
        shoePropertiesArray[1]= "Model";
        shoePropertiesArray[2]= "Size";
        shoePropertiesArray[3]= "Width";
        shoePropertiesArray[4]= "Measured Length";
        shoePropertiesArray[5]= "Measured Width";
        shoePropertiesArray[6]= "FlatFoot status";
        shoePropertiesArray[7]= "HeelPain status";
        shoePropertiesArray[8]= "HammerToe status";
    
        return (shoePropertiesArray[index-1]);//return the actual member variable or name?
    }

}

class Shoe
{
    //member variables___________________________________________________________________
    private string _brand;
    private string _model;
    private float _sizeShoe;
    private string _widthShoe;

    private float _lengthMeasuredShoe;
    private float _widthMeasuredShoe;
    private List<Pathology> _pathListShoe;




//Constructors_________________________________________________________________________

    public Shoe()
    {
        _pathListShoe = new List<Pathology>();
    }
    
    public Shoe(string brand, string model, float sizeShoe, string widthShoe, float lengthMeasuredShoe, float widthMeasuredShoe, params Pathology[] pathListShoe)// new const to hold the shoe path list rather than the bools
    {
        _brand = brand;
        _model = model;
        _sizeShoe = sizeShoe;
        _widthShoe = widthShoe;
        _lengthMeasuredShoe = lengthMeasuredShoe;
        _widthMeasuredShoe = widthMeasuredShoe;
        _pathListShoe = new List<Pathology> (pathListShoe);

    }
    
//properties and getters and setters - 
    public string Brand//here I'm trying a different notation that can be used to create a property and then use the property to directly access the private member variable. I like this method as it is easier to type
    {
        get => _brand;
        set => _brand = value;
    }
    
    public string Model
     {
        get => _model;
        set => _model = value;
    }
    public float SizeShoe 
     {
        get => _sizeShoe;
        set => _sizeShoe = value;
    }
    public string WidthShoe
     {
        get => _widthShoe;
        set => _widthShoe = value;
    }
    public float LengthMeasuredShoe
     {
        get => _lengthMeasuredShoe;
        set => _lengthMeasuredShoe = value;
    }
    public float WidthMeasuredShoe
     {
        get => _widthMeasuredShoe;
        set => _widthMeasuredShoe = value;
    }

    public List<Pathology> ShoePathList// property to get and set the list of path for the shoe
     {
        get => _pathListShoe;
        set => _pathListShoe = value;
    }
    

//Methods______________________________________________________________________


public void DisplayShoeDetails()//to replace DisplayShoe()
{
    Console.Write($"Brand: {_brand}, Model: {_model}, Size: {_sizeShoe}, Width: {_widthShoe}, Measured Length: {_lengthMeasuredShoe}, Measured Width: {_widthMeasuredShoe}, Approved Pathogogies: ");
    foreach (Pathology path in _pathListShoe)
    {
        Console.Write($"{path.PathName},");
    }
    Console.WriteLine();
}
public void CreateShoe()
{
    Shoe shoe = new Shoe();// new shoe

    Console.WriteLine("Brand:");
    _brand = Console.ReadLine().Trim();
    Console.WriteLine("Model:");
    _model = Console.ReadLine().Trim();
    Console.WriteLine("Size:");    
    _sizeShoe = float.Parse(Console.ReadLine());
    Console.WriteLine("Width:");
    _widthShoe = Console.ReadLine();
    Console.WriteLine("Measured Length:");
    _lengthMeasuredShoe = float.Parse(Console.ReadLine());
    Console.WriteLine("Measured Width:");
    _widthMeasuredShoe = float.Parse(Console.ReadLine());

    Console.WriteLine("Flat Foot Approved? Enter y for yes or any other key for no");
    string answer1 = Console.ReadLine().ToLower();
        if (answer1 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
        {
            FlatFoot flatFoot = new FlatFoot();
            _pathListShoe.Add(flatFoot);
        }
        
    Console.WriteLine("Heel Pain Approved? Enter y for yes or any other key for no");
    string answer2 = Console.ReadLine().ToLower();
        if (answer2 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
        {
            HeelPain heelPain = new HeelPain();
            _pathListShoe.Add(heelPain);
        }
            
    Console.WriteLine("Hammer Toe Approved? Enter y for yes or any other key for no");
    string answer3 = Console.ReadLine().ToLower();
        if (answer3 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
        {
            HammerToes hammerToes = new HammerToes();
            _pathListShoe.Add(hammerToes);
        }

        

    //return shoe;
}

public string CreateNewShoeFileEntry()//to replace createShoeFIleEntry
{
    string a = $"{_brand},{_model},{_sizeShoe},{_widthShoe},{_lengthMeasuredShoe},{_widthMeasuredShoe},";
    string b = DisplayShoePathListString();
    
    return  a + b;
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
            Console.WriteLine($"3. Size: {_sizeShoe}");
            Console.WriteLine($"4. Width: {_widthShoe}");
            Console.WriteLine($"5. Measured Length: {_lengthMeasuredShoe}");
            Console.WriteLine($"6. Measured Width: {_widthMeasuredShoe}");
            Console.WriteLine($"7. Approved Pathologies: ");//{_pathListShoe[0].GetType().Name}");// this may need to be iterattive list instead? or just leave as pathogy;
            DisplayShoePathList();


            Console.WriteLine("Enter the number of the item you wish to edit.");
            string selectionString = Console.ReadLine();
            
            int selectionInt;
        
            
            bool done3 = false;
            while (!done3)
            {
                    
                    if (int.TryParse(selectionString, out selectionInt)  && selectionInt >=1 && selectionInt <= 7)// try to parse to an int, and if it is, go ahead and output the value
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
                        float number;

                        if (float.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _sizeShoe = number;//parsing is successful
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
                _widthShoe = newEntry;//parsing is successful
                                     
                break;

                case "5":
                {
                    bool allDone = false;
                    while (!allDone)
                    {
                        float number;

                        if (float.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _lengthMeasuredShoe = number;//parsing is successful
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
                        float number;

                        if (float.TryParse(newEntry, out number))//using a tryParse to send an error option if a number is not entered
                        {
                            _widthMeasuredShoe = number;//parsing is successful
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
                    
                        Console.WriteLine("Flat Foot Approved? Enter y for yes or any other key for no");
                        string answer1 = Console.ReadLine().ToLower();
                        if (answer1 == "y")//if we do want it
                        {
                            FlatFoot flatFoot = new FlatFoot();
                            if (_pathListShoe.Contains(flatFoot))//already on the list
                            {
                                //do nothing
                            }
                            else//add it to the list
                            {
                                 _pathListShoe.Add(flatFoot);

                            }
                          
                        }
                        else//if we don't want it as part of the list of shoe pathologies
                        {
                            FlatFoot flatFoot = new FlatFoot();
                            if (_pathListShoe.Contains(flatFoot))
                            {
                                _pathListShoe.Remove(flatFoot);//remove it
                            }
                            else
                            {
                                //do nothing
                            }

                        }
        
                        Console.WriteLine("Heel Pain Approved? Enter y for yes or any other key for no");
                        string answer2 = Console.ReadLine().ToLower();
                        if (answer2 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
                       {
                            HeelPain heelPain = new HeelPain();
                            if (_pathListShoe.Contains(heelPain))//already on the list
                            {
                                //do nothing
                            }
                            else//add it to the list
                            {
                                 _pathListShoe.Add(heelPain);

                            }
                          
                        }
                        else//if we don't want it as part of the list of shoe pathologies
                        {
                            HeelPain heelPain = new HeelPain();
                            if (_pathListShoe.Contains(heelPain))
                            {
                                _pathListShoe.Remove(heelPain);//remove it
                            }
                            else
                            {
                                //do nothing
                            }

                        }
                            
                        Console.WriteLine("Hammer Toe Approved? Enter y for yes or any other key for no");
                        string answer3 = Console.ReadLine().ToLower();
                        if (answer3 == "y")//since we default all shoes to NO on these values, we should only need a Y to change.
                       {
                            HammerToes hammerToes = new HammerToes();
                            if (_pathListShoe.Contains(hammerToes))//already on the list
                            {
                                //do nothing
                            }
                            else//add it to the list
                            {
                                 _pathListShoe.Add(hammerToes);

                            }
                          
                        }
                        else//if we don't want it as part of the list of shoe pathologies
                        {
                            HammerToes hammerToes = new HammerToes();
                            if (_pathListShoe.Contains(hammerToes))
                            {
                                _pathListShoe.Remove(hammerToes);//remove it
                            }
                            else
                            {
                                //do nothing
                            }

                        }
                                        

                        
                        
                    //}
                    
                }
                break;
               
                default:
                Console.WriteLine("You have made an invalid entry, please try again.");
                continue;
           }

            
        
            Console.WriteLine("Edits have been saved.  Here's the updated shoe: ");
            DisplayShoeDetails();
           
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
public void DisplayShoePathList()
{
    foreach (Pathology path in _pathListShoe)
    {
        Console.Write($"{path.PathName},");
    }
    Console.WriteLine();

}
public string DisplayShoePathListString()
{
    string a = "";
    foreach (Pathology path in _pathListShoe)
    {
        a += ($"{path.PathName},");
    }
    
    return a;
}
private object ShoePropertiesIndex(int index)// a method to hold and array and return the name of the property when given an index
    {
        
        object[] shoePropertiesArray = new object[7];  //creating an array of objects to refence our variabes by number
        shoePropertiesArray[0]= "Brand";
        shoePropertiesArray[1]= "Model";
        shoePropertiesArray[2]= "Size";
        shoePropertiesArray[3]= "Width";
        shoePropertiesArray[4]= "Measured Length";
        shoePropertiesArray[5]= "Measured Width";
        shoePropertiesArray[6]= "Approved Pathology...press Enter to proceed";
        // shoePropertiesArray[6]= "FlatFoot status";
        // shoePropertiesArray[7]= "HeelPain status";
        // shoePropertiesArray[8]= "HammerToe status";
    
        return (shoePropertiesArray[index-1]);//return the actual member variable or name?
    }

}
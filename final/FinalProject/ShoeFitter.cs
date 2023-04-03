class ShoeFitter
{
    private Foot _footProfile;
    private List<Shoe> _shoeList;
    private List<Shoe> _recShoeList; //recommended shoes list.  For now we are not going to store this anywhere, but could be stored as user variable
    private bool lengthGood = false;//some bools to handle weather the shoe gets added to the rec shoes list
    private bool widthGood = false;
    private bool sizeGood = false;
    // private bool pathGood = true;
    // private bool flatFootApproved= true;//we'll set these to true as we want shoes to get through to the list, unless a foot HAS a pathology that the shoe DOESNT,
    // private bool heelPainApproved = true;
    // private bool hammerToesApproved = true;
    // private bool pathFlatFoot = false;
    // private bool pathHeelPain = false;
    // private bool pathHammertoes = false;

    
    // constructors

    public ShoeFitter()
    {
        _recShoeList = new List<Shoe>();
    }
    public ShoeFitter(Foot footProfile, List<Shoe> shoeList)
    {
        _footProfile = footProfile;
        _shoeList = shoeList;
        _recShoeList = new List<Shoe>();
    }

    //
    public List<Shoe> RecShoeList
    {
        get => _recShoeList;
        set => _recShoeList = value;
        
    }

    //Methods------------------------
    public List<Shoe> RunShoeFitter(Foot footProfile, List<Shoe> shoeList)
    {
        
    foreach (Shoe shoe in shoeList)
    {
        
        lengthGood = false;
        widthGood = false;
        sizeGood = false;
        //pathGood = true;

        if (shoe.LengthMeasuredShoe >= footProfile.LengthMeasuredFoot + 1 && shoe.LengthMeasuredShoe <= footProfile.LengthMeasuredFoot + 1.3)//leaving a bit of space for toes
        {
            lengthGood = true;
            Console.WriteLine($"the Length is good on the {shoe.Brand} {shoe.Model}");
            Thread.Sleep(1000);
        }
        
        if (shoe.WidthMeasuredShoe >= footProfile.WidthMeasuredFoot + 0.25 && shoe.WidthMeasuredShoe <= footProfile.WidthMeasuredFoot + 0.5)//leaving some room for foot width
        {
            widthGood = true;
            Console.WriteLine($"the Width is good on the {shoe.Brand} {shoe.Model}");
            Thread.Sleep(1000);
        }
        

        if (lengthGood == true && widthGood == true)
        {
            sizeGood = true;
            Console.WriteLine($"the Size is correct for the the {shoe.Brand} {shoe.Model}");
            Thread.Sleep(1000);
        }
        

        //     Pathology flatFoot = new FlatFoot();
        //     Pathology heelPain = new HeelPain();
        //     Pathology hammerToes = new HammerToes();

        // if (footProfile.PathListFoot.Contains(flatFoot)  && !shoe.ShoePathList.Contains(flatFoot))//if our foot has a pathology and the shoe does not...set to false, shoe no good 
        // {
        //     //flatFootApproved= false;
        //     pathGood = false;
        //     Console.Write($"the foot has a flatfoot and the shoe does not qualify");
        //     Thread.Sleep(1000);
        // }
       
        // if (footProfile.PathListFoot.Contains(heelPain) && !shoe.ShoePathList.Contains(heelPain))
        // {
        //     //heelPainApproved= false;
        //     pathGood = false;
        //     Console.Write($"the foot has heel pain and the shoe does not qualify");
        //     Thread.Sleep(1000);
        // }
        // if (footProfile.PathListFoot.Contains(hammerToes) && !shoe.ShoePathList.Contains(hammerToes))
        // {
        //     //hammerToesApproved= false;
        //     pathGood = false;
        //      Console.Write($"the foot has hammertoes and the shoe does not qualify");
        //      Thread.Sleep(1000);
        // }

        //this pathology matching component is not working, but seems like it should. I give up for now......can't spend afford to spend another 40 hours on this

        if (sizeGood == true)// && pathGood == true)
        {
            _recShoeList.Add(shoe);
           
        }
            

    }

    return _recShoeList;
    }
    public void DisplayShoeFitterList(List<Shoe> recShoeList)
    {
        //string shoeListString = "";
        Console.WriteLine();
        Console.WriteLine("Displaying shoe recommendations:");
        foreach (Shoe shoe in recShoeList)
        {
            Console.WriteLine($"Brand:{shoe.Brand}, Model:{shoe.Model}, Size:{shoe.SizeShoe}, Width:{shoe.WidthShoe}");
        }

        //return shoeListString;
    } 

}
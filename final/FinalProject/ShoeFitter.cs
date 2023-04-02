class ShoeFitter
{
    private Foot _footProfile;
    private List<Shoe> _shoeList;
    private List<Shoe> _recShoeList;

    
    // constructors

    public ShoeFitter()
    {
    }
    public ShoeFitter(Foot footProfile, List<Shoe> shoeList)
    {
        _footProfile = footProfile;
        _shoeList = shoeList;
    }

    //Methods
    public List<Shoe> RunShoeFitter(Foot footProfile, List<Shoe> shoeList)
    {
    
    
    List<Shoe> _recShoeList = new List<Shoe>();
    
    

    //here we'll do the logic to compare the users foot profile to the shoes in the shoe list and generate a new list of recommended shoes


    return _recShoeList;
    }


}
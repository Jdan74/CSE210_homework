class Orthotic
{

private string _brand;
private string _model;
private string _description;
private string _size;
private List<Pathology> _pathListOrthotic;


//constructors

public Orthotic ()
{

}
public Orthotic (string brand, string model, string description)//we'll instantiate the orthotics in the main program
{
    _brand = brand;
    _model = model;
    _description = description;
    // _size = size; // we'll try to get size from child class specific methods
    // _pathListOrthotic = pathListOrthotics;//we'll try to get pathology from child class specific methods

}
//methods

public virtual void GetOrthoticRec()
{

    

}

}
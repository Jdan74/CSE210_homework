class User

{
//variables
private string _nameFirst;
private string _nameLast;
private Foot _footProfile;
private List<Pathology> _footPathList;
private List<Shoe> _recShoeList;


//constuctors
public User()
{

}
public User(string nameFirst, string nameLast, Foot footProfile, List<Pathology> footPathList)
{
    _nameFirst = nameFirst;
    _nameLast =  nameLast;
    _footProfile = footProfile;
    _footPathList = footPathList;

}

// getters and setters - none yet

//Methods

public void DisplayProfile()
{

}
public void EditProfile()
{

}
public void DeleteProfile()
{

}
public void CreateProfile()
{

}
public void CreateFootProfile()
{

}
public void EditFootProfile()
{

}


}
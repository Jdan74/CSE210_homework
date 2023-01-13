 
 
 //The responsibility of a job is to Keeps track of the company, job title, start year, and end year.
    public class Job
    {
        // The C# convention is to start member variables with an underscore _
        public string _jobTitle;
        public string _company;
        public int _startYear;
        public int _endYear;

        // A special method, called a constructor that is invoked using the  
        // new keyword followed by the class name and parentheses.
        public Job()// Does this constructor not need to be here?
        {
        }

        // A method (or member function) that displays the person's job title company and years of employement 
        
        public void DisplayJobDetails()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }

        
    }

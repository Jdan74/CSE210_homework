public class Resume
    {
        // The C# convention is to start member variables with an underscore _
        public string _name;
        public List<Job> _jobs = new List<Job>();//declaring a member variable called _jobs which will contain 
                                                //a list of objects of type Job.  THEN we have to initialize 
                                                //it using the constuctor....otherwise it doesn't actually 
                                                //exist!!!!!!!
        

        // A special method, called a constructor that is invoked using the  
        // new keyword followed by the class name and parentheses.
        public Resume()//declaring the constructor not necessary?
        {
        }

        // A method that displays the Resume name and jobs 
    
        public void DisplayResumeDetails()//createing a display Resume method in our Resume Class
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs: ");
            
            foreach(var job in _jobs)//this works, but noticed in answer/example code had used Job instead of var? 
            {
                job.DisplayJobDetails();//calling our display details method we created in the Job class
            }
            

        }

        
    }

using System;


class Program
{
    static void Main(string[] args)
    {
       Job job1 = new Job();
       job1._company = "Apple";
       job1._jobTitle = "Software Engineer";
       job1._startYear = 2000;
       job1._endYear = 2020;

       Job job2 = new Job();
       job2._company = "Microsoft";
       job2._jobTitle = "Manager";
       job2._startYear = 2005;
       job2._endYear = 2015;


       job1.DisplayJobDetails();
       job2.DisplayJobDetails();

        Resume newResume = new Resume();
        newResume._name = "Steve Jobbs";
        newResume._jobs.Add(job1);
        newResume._jobs.Add(job2);

       
{
        newResume.DisplayResumeDetails();//calling the method to display the list of jobs from our Resume class
}



       
       

    }
}
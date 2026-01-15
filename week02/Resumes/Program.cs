using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new();
        resume._name = "Allison Rose";

        Job job1 = new();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        resume._jobs.Add(job1);

        Job job2 = new();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        resume._jobs.Add(job2);

        resume.Display();
    }
}
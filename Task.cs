namespace Midterm;

public class Task : Ticket
{
    public string ProjectName { get; set; }
    public DateOnly DueDate { get; set; }

    public Task() : base()
    {
        Console.WriteLine("What is the project name?");
        ProjectName = Console.ReadLine();

        Console.WriteLine("What is the due date for the task (yyyy/MM/dd)?");
        DueDate = DateOnly.Parse(Console.ReadLine());


    }
}


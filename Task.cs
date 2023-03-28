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

    public Task(string id, string summary, string status, string priority, 
        string assigned, string submitter, List<string> watching, 
        string ProjectName, string DueDate) : base(id, summary, status, priority, assigned, submitter, watching)
    {
        this.TicketID = Convert.ToInt32(id);
        this.Summary = summary;
        this.Assigned = assigned;
        this.Status = status;
        this.Priority = priority;
        this.Submitter = submitter;
        this.Watching = watching;
        this.ProjectName = ProjectName;
        this.DueDate = DateOnly.Parse(DueDate);
    }
}


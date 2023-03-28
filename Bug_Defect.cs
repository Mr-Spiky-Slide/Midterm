namespace Midterm;

public class Bug_Defect : Ticket
{
    public string Severity { get; set; }

    public Bug_Defect() : base()
    {
        Console.WriteLine("Enter severity of ticket (High, Medium, Low):");
        Severity = Console.ReadLine();

    }

    public Bug_Defect(string id, string summary, string status, 
        string priority, string assigned, string submitter, List<string> 
        watching, string severity) : base(id, summary, status, priority, assigned, submitter, watching)
    {
        this.TicketID = Convert.ToInt32(id);
        this.Summary = summary;
        this.Assigned = assigned;
        this.Status = status;
        this.Priority = priority;
        this.Submitter = submitter;
        this.Watching = watching;
        this.Severity = severity;
    }

    
        
}
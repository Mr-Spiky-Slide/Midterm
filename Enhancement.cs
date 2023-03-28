namespace Midterm;

public class Enhancement : Ticket
{
    public string Software { get; set; }
    public double Cost { get; set; }
    public string Reason { get; set; }
    public TimeSpan Estimate { get; set; }

    public Enhancement() : base()
    {
        Console.WriteLine("What software is the issue on?");
        Software = Console.ReadLine();

        Console.WriteLine("What is the estimated cost?");
        Cost = Double.Parse(Console.ReadLine());

        Console.WriteLine("What is the reason for this enhancement?");
        Reason = Console.ReadLine();

        Console.WriteLine("What is the time estimate (hours:minutes:seconds)");
        Estimate = TimeSpan.Parse(Console.ReadLine());

    }

    public Enhancement(string id, string summary, string status, 
        string priority, string assigned, string submitter, 
        List<string> watching, string software, string cost, 
        string reason, string Estimate) : base(id, summary, status, priority, assigned, submitter, watching)
    {
        this.TicketID = Convert.ToInt32(id);
        this.Summary = summary;
        this.Assigned = assigned;
        this.Status = status;
        this.Priority = priority;
        this.Submitter = submitter;
        this.Watching = watching;
        this.Software = software;
        this.Cost = Convert.ToDouble(cost);
        this.Reason = reason;
        this.Estimate = TimeSpan.Parse(Estimate);
    }

}

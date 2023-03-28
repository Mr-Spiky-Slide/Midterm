namespace Midterm;


public abstract class Ticket
{
    //Properties
    public int TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Assigned { get; set; }
    public string Submitter { get; set; }
    public List<string> Watching = new List<String>();

    public Ticket(string id, string summary, string status, string priority,
            string assigned, string submitter, List<string> watching)
    {
        this.TicketID = Convert.ToInt32(id);
        this.Summary = summary;
        this.Assigned = assigned;
        this.Status = status;
        this.Priority = priority;
        this.Submitter = submitter;
        this.Watching = watching;
    }
    public Ticket()
    {
        Console.WriteLine("Enter a unique TicketID: ");
        TicketID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter ticket summary: ");
        Summary = Console.ReadLine();

        Console.WriteLine("Enter ticket status (Open, Closed): ");
        Status = Console.ReadLine();

        Console.WriteLine("Enter ticket priority (High, Medium , Low): ");
        Priority = Console.ReadLine();

        Console.WriteLine("Enter ticket Assignee: ");
        Assigned = Console.ReadLine();

        Console.WriteLine("Enter ticket Submitter: ");
        Submitter = Console.ReadLine();

        bool loopList = true;
        while (loopList == true)
        {
            Console.WriteLine("Enter watcher name or ~ to stop: ");
            string inputWatch = Console.ReadLine();
            if (inputWatch == "~")
            {
                loopList = false;
            }
            else
            {
                Watching.Add(inputWatch);
            }
        }

    }



}
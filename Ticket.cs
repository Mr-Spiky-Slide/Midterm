namespace Midterm;


public abstract class Ticket
{
    //Properties
    public int TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }

    //maybe change to enum
    public string Priority { get; set; }
    public string Assigned { get; set; }
    public string Submitter { get; set; }
    public List<string> Watching = new List<String>();

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

    public virtual void readFile(string file){
        if (File.Exists(file))
        {
            // read data from file
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string watchersStr = null;
                string line = sr.ReadLine();
                // convert string to array, splitting it at the comma "," 
                string[] arr = line.Split(',');
                //Organize the watchers
                string[] watchers = arr[6].Split('|');

                foreach (string name in watchers)
                {
                    watchersStr += name;
                }
                //display array data
                Console.WriteLine($"TicketID: {arr[0]}, Summary: {arr[1]}, Status: {arr[2]}, Priority: {arr[3]}, Submitter: {arr[4]}, Assigned: {arr[5]}, Watching: {watchersStr}");
                
            }
            sr.Close();
            
        }
        else
        {
            Console.WriteLine("File does not exist");
        }

    }

}



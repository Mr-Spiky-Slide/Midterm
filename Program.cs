using NLog;
using Midterm;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string ticketFile = "tickets.csv";
string enhancementFile = "enhancements.csv";
string taskFile = "task.csv";

string choice;

string searchChoice;


do
{
    // ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("3) Search");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("Which file would you like to read from? \n 1. Bugs/Defects \n 2. Enhancements \n 3. Tasks ");
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                readBugDefect(ticketFile);
                break;
            case 2:
                readEnhancement(enhancementFile);
                break;
            case 3:
                readTask(taskFile);
                break;
            default:
                logger.Info("Please enter a number 1 - 3");
                break;

        }


    }
    else if (choice == "2")
    {
        bool addTicket = false;
        do
        {

            Console.WriteLine("Which file would you like to read from? \n 1. Bugs/Defects \n 2. Enhancements \n 3. Tasks ");
            string ticketChoice = Console.ReadLine();
            switch (ticketChoice)
            {
                case "1":
                    writeBugDefect(ticketFile);
                    break;
                case "2":
                    writeEnhancement(enhancementFile);
                    break;
                case "3":
                    writeTask(taskFile);
                    break;
                default:
                    logger.Info("Please enter a number 1 - 3");
                    break;
            }
            Console.WriteLine("Add another ticket? (Y/N)");
            string resp = Console.ReadLine().ToUpper();
            if (resp == "Y") { addTicket = true; }
            else if (resp == "N") { addTicket = false; }
        } while (addTicket);
    }
    else if (choice == "3")
    {
        AllTickets allTickets = new AllTickets(ticketFile, enhancementFile, taskFile);
        do
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("  1) Status");
            Console.WriteLine("  2) Priority ");
            Console.WriteLine("  3) Submitter");
            Console.WriteLine("Enter any other key to exit.");

            searchChoice = Console.ReadLine();

            
            

            if(searchChoice == "1"){
                Console.WriteLine("Enter search parameters: ");
                string searchWord = Console.ReadLine();
                Console.WriteLine($"There are {allTickets.Tickets.Where(t => t.Status.Contains(searchWord)).Count()} tickets with a status of {searchWord}");
                var matchingTickets = allTickets.Tickets.Where(t => t.Status.Contains(searchWord));
                foreach (Ticket ticket in matchingTickets){
                    Console.WriteLine($"  ID: {ticket.TicketID} Summary: {ticket.Summary} Status: {ticket.Status}");
                }
            }
            else if(searchChoice == "2"){
                Console.WriteLine("Enter search parameters: ");
                string searchWord = Console.ReadLine();
                Console.WriteLine($"There are {allTickets.Tickets.Where(t => t.Priority.Contains(searchWord)).Count()} tickets with a status of {searchWord}");
                var matchingTickets = allTickets.Tickets.Where(t => t.Priority.Contains(searchWord));
                foreach (Ticket ticket in matchingTickets){
                    Console.WriteLine($"  ID: {ticket.TicketID} Summary: {ticket.Summary} Priority: {ticket.Priority}");
                }
            }
            else if(searchChoice == "3"){
                Console.WriteLine("Enter search parameters: ");
                string searchWord = Console.ReadLine();
                Console.WriteLine($"There are {allTickets.Tickets.Where(t => t.Submitter.Contains(searchWord)).Count()} tickets with a status of {searchWord}");
                var matchingTickets = allTickets.Tickets.Where(t => t.Submitter.Contains(searchWord));
                foreach (Ticket ticket in matchingTickets){
                    Console.WriteLine($"  ID: {ticket.TicketID} Summary: {ticket.Summary} Submitter: {ticket.Submitter}");
                }
            }

        } while (searchChoice == "1" || searchChoice == "2" || searchChoice == "3");


    }
} while (choice == "1" || choice == "2" || choice == "3");




static void readBugDefect(string file)

{
    if (File.Exists(file))
    {
        // read data from file
        StreamReader sr = new StreamReader(file);
        Console.WriteLine("TicketID, Summary, Status, Priority, Assigned, Submitter, Watching, Severity");
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

            Console.WriteLine($"TicketID: {arr[0]}, Summary: {arr[1]}, Status: {arr[2]}, Priority: {arr[3]}, Submitter: {arr[4]}, Assigned: {arr[5]}, Watching: {watchersStr}, Severity: {arr[7]}");

        }
        sr.Close();

    }
    else
    {
        Console.WriteLine("File does not exist");
    }

}

static void writeBugDefect(string file)
{
    // create file from data
    StreamWriter sw1 = new StreamWriter(file, append: true);

    string watchers = null;
    Bug_Defect t = new Bug_Defect();
    int amount = t.Watching.Count();
    for (int j = 0; j < amount; j++)
    {
        if (j + 1 == amount)
        {
            watchers += t.Watching[j];
        }
        else
        {
            watchers += $"{t.Watching[j]}|";
        }
    }
    sw1.WriteLine($"{t.TicketID},{t.Summary},{t.Status},{t.Priority},{t.Assigned},{t.Submitter},{watchers},{t.Severity}");

    sw1.Close();


}

static void readEnhancement(string file)

{
    if (File.Exists(file))
    {
        // read data from file
        StreamReader sr = new StreamReader(file);
        Console.WriteLine("TicketID, Summary, Status, Priority, Assigned, Submitter, Watching, Software, Cost, Reason, Estimate");
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
            Console.WriteLine($"TicketID: {arr[0]}, Summary: {arr[1]}, Status: {arr[2]}, Priority: {arr[3]}, Submitter: {arr[4]}, Assigned: {arr[5]}, Watching: {watchersStr}, Software: {arr[7]}, Cost: {arr[8]}, Reason: {arr[9]}, Estimate: {arr[10]}");

        }
        sr.Close();

    }
    else
    {
        Console.WriteLine("File does not exist");
    }

}

static void writeEnhancement(string file)
{

    // create file from data
    StreamWriter swE = new StreamWriter(file, append: true);

    string watchers = null;
    Enhancement t = new Enhancement();
    int amount = t.Watching.Count();
    for (int j = 0; j < amount; j++)
    {
        if (j + 1 == amount)
        {
            watchers += t.Watching[j];
        }
        else
        {
            watchers += $"{t.Watching[j]}|";
        }
    }
    swE.WriteLine($"{t.TicketID},{t.Summary},{t.Status},{t.Priority},{t.Assigned},{t.Submitter},{watchers},{t.Software},{t.Cost},{t.Reason},{t.Estimate}");

    swE.Close();


}

static void readTask(string file)

{
    if (File.Exists(file))
    {
        // read data from file
        StreamReader sr = new StreamReader(file);
        Console.WriteLine("TicketID, Summary, Status, Priority, Assigned, Submitter, Watching, Project Name, Due Date");
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
            Console.WriteLine($"TicketID: {arr[0]}, Summary: {arr[1]}, Status: {arr[2]}, Priority: {arr[3]}, Submitter: {arr[4]}, Assigned: {arr[5]}, Watching: {watchersStr}, Project Name: {arr[7]}, Due Date: {arr[8]}");

        }
        sr.Close();

    }
    else
    {
        Console.WriteLine("File does not exist");
    }

}

static void writeTask(string file)
{

    // create file from data
    StreamWriter swT = new StreamWriter(file, append: true);

    string watchers = null;
    Midterm.Task t = new Midterm.Task();
    int amount = t.Watching.Count();
    for (int j = 0; j < amount; j++)
    {
        if (j + 1 == amount)
        {
            watchers += t.Watching[j];
        }
        else
        {
            watchers += $"{t.Watching[j]}|";
        }
    }
    swT.WriteLine($"{t.TicketID},{t.Summary},{t.Status},{t.Priority},{t.Assigned},{t.Submitter},{watchers},{t.ProjectName},{t.DueDate}");

    swT.Close();


}












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

StreamWriter sw0 = new StreamWriter(taskFile);
sw0.WriteLine("TicketID, Summary, Status, Priority, Assigned, Submitter, Watching");
sw0.Close();

do
{
    // ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        string file = null;
        Console.WriteLine("Which file would you like to read from? \n 1. Bugs/Defects \n 2. Enhancements \n 3. Tasks ");
        switch (Convert.ToInt32(Console.ReadLine))
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
        // read data from file
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
} while (choice == "1" || choice == "2");


static void readBugDefect(string file)

{
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












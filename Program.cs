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
bool addTicket = false;

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
                string lßine = sr.ReadLine();
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
        do
        {
            // create file from data
            StreamWriter sw1 = new StreamWriter(taskFile, append: true);

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
            sw1.WriteLine($"{t.TicketID},{t.Summary},{t.Status},{t.Priority},{t.Assigned},{t.Submitter},{watchers}");

            sw1.Close();

            Console.WriteLine("Add another ticket? (Y/N)");
            string resp = Console.ReadLine().ToUpper();
            if (resp == "Y") { addTicket = true; }
            else if (resp == "N") { addTicket = false; }
        } while (addTicket);
    }
} while (choice == "1" || choice == "2");
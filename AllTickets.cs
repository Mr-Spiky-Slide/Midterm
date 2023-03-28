using NLog;
namespace Midterm;

public class AllTickets
{
    public string filePath1 { get; set; }
    public string filePath2 { get; set; }
    public string filePath3 { get; set; }
    public List<Ticket> Tickets { get; set; }

    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "//nlog.config").GetCurrentClassLogger();

    public AllTickets(string filePath1, string filePath2, string filePath3)
    {
        this.filePath1 = filePath1;
        Tickets = new List<Ticket>();

        //for the bugs and defects
        StreamReader sr = new StreamReader(filePath1);
        while(!sr.EndOfStream)
        {

            string line = sr.ReadLine();
            List<string> watcherList = new List<string>();
            // convert string to array, splitting it at the comma "," 
            string[] arr = line.Split(',');
            //Organize the watchers
            string[] watchers = arr[6].Split('|');

            foreach (string name in watchers)
            {
                watcherList.Add(name);
            }

            Bug_Defect defect = new Bug_Defect(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], watcherList, arr[7]);

            Tickets.Add(defect);
            
        }
        sr.Close();
        //for the enhancements
        StreamReader sr1 = new StreamReader(filePath2);
        while(!sr1.EndOfStream)
        {

            string line = sr1.ReadLine();
            List<string> watcherList1 = new List<string>();
            // convert string to array, splitting it at the comma "," 
            string[] arr1 = line.Split(',');
            //Organize the watchers
            string[] watchers1 = arr1[6].Split('|');

            foreach (string name in watchers1)
            {
                watcherList1.Add(name);
            }

            Enhancement enhancement = new Enhancement(arr1[0], arr1[1], arr1[2], arr1[3], arr1[4], arr1[5], watcherList1, arr1[7], arr1[8], arr1[9], arr1[10]);

            Tickets.Add(enhancement);
            
        }
        sr1.Close();
        //for the tasks
        StreamReader sr2 = new StreamReader(filePath3);
        while(!sr2.EndOfStream)
        {

            string line = sr2.ReadLine();
            List<string> watcherList2 = new List<string>();
            // convert string to array, splitting it at the comma "," 
            string[] arr2 = line.Split(',');
            //Organize the watchers
            string[] watchers2 = arr2[6].Split('|');

            foreach (string name in watchers2)
            {
                watcherList2.Add(name);
            }

            Task task = new Task(arr2[0], arr2[1], arr2[2], arr2[3], arr2[4], arr2[5], watcherList2, arr2[7], arr2[8]);

            Tickets.Add(task);
            
        }
        sr2.Close();
    }
}


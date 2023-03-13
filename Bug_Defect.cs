namespace Midterm;

public class Bug_Defect : Ticket
{
    public string Severity { get; set; }

    public Bug_Defect() : base()
    {
        Console.WriteLine("Enter severity of ticket (High, Medium, Low):");
        Severity = Console.ReadLine();


    }

    public virtual string readFile(string file){
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
                return($"TicketID: {arr[0]}, Summary: {arr[1]}, Status: {arr[2]}, Priority: {arr[3]}, Submitter: {arr[4]}, Assigned: {arr[5]}, Watching: {watchersStr}");
                
            }
            sr.Close();
            
        }
        else
        {
            return("File does not exist");
        }
        
    }
}
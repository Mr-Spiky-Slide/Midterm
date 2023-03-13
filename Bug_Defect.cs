namespace Midterm;

public class Bug_Defect : Ticket{
    public string Severity { get; set; }

    public Bug_Defect() : base(){
        Console.WriteLine("Enter severity of ticket (High, Medium, Low):");
        Severity = Console.ReadLine();
        

    }
}
namespace Midterm;

public class Enhancement
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

}

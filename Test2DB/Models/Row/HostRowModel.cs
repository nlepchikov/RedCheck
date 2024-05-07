namespace Test2DB.Models.Row;

public class HostRowModel: RowModel
{
    public int Id { get; set; }
    
    public int CriticalCount { get; set; }

    public int HighCount { get; set; }

    public int MediumCount { get; set; }

    public int LowCount { get; set; }
    
    public string Host { get; set; }
}
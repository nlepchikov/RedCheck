namespace Test2DB.Models.Row;

public class ReportRowModel: RowModel
{
    public int Id { get; set; }
    
    public string ReportNumber { get; set; }
    
    public string Name { get; set; }
    
    public string Hosts { get; set; }
    
    public string Tasks { get; set; }
    public string Profile { get; set; }
    
    public DateTime StartScan { get; set; }
    
    public DateTime EndScan { get; set; }
    
    public DateTime ReportCreate { get; set; }
}
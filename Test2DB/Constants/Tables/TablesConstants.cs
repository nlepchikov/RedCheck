namespace ConsoleApp1.Constants.Tables;

public class TablesConstants
{
    public const string ReportTableTitle = "ОТЧЁТ";
    
    public const string LevelRisksTableTitle = "Диаграмма&nbsp;распределения&nbsp;уязвимостей&nbsp;по&nbsp;уровням&nbsp;риска";
    
    public const string HostsTableTitle = "Таблица&nbsp;распределения&nbsp;уязвимостей&nbsp;по&nbsp;хостам";
    
    public const string ProductsTableTitle = "Таблица&nbsp;распределения&nbsp;уязвимостей&nbsp;по&nbsp;продуктам";
    
    public const string CriticalVulnerabilityTableTitle = "Риск:&nbsp;Критический"; 
    
    public const string HighVulnerabilityTableTitle = "Риск:&nbsp;Высокий"; 
    
    public const string MediumVulnerabilityTableTitle = "Риск:&nbsp;Средний"; 
    
    public const string LowVulnerabilityTableTitle = "Риск:&nbsp;Низкий"; 
    
    public const string VulnerabilityDescriptionTableTitle = "Список&nbsp;уязвимостей";

    public static readonly string[] TableTitles = new string[]
    {
        ReportTableTitle,
        LevelRisksTableTitle,
        HostsTableTitle,
        ProductsTableTitle,
        CriticalVulnerabilityTableTitle,
        HighVulnerabilityTableTitle,
        MediumVulnerabilityTableTitle,
        LowVulnerabilityTableTitle,
        VulnerabilityDescriptionTableTitle,
    };
    
    public static readonly string[] VulnTablesTitles = new string[]
    {
        CriticalVulnerabilityTableTitle,
        HighVulnerabilityTableTitle,
        MediumVulnerabilityTableTitle,
        LowVulnerabilityTableTitle,
        VulnerabilityDescriptionTableTitle,
    };
}
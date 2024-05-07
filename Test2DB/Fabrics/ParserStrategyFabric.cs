using ConsoleApp1.Constants.Tables;
using ConsoleApp1.Parser;

namespace ConsoleApp1.Fabrics;

public class ParserStrategyFabric
{
    /// <param name="row"></param>
    /// <returns>ParseRowStrategy?</returns>
    public static ParseRowStrategy GetByTableName(string row = "")
    {
        Dictionary<string, ParseRowStrategy> strategies = GetParseRowStrategiesList();
        
        if (strategies.ContainsKey(row))
        {
            return strategies[row];
        }
        
        return new EmptyParseRowStrategy();
    }

    /// <returns>Dictionary<string, ParseRowStrategy></returns>
    private static Dictionary<string, ParseRowStrategy> GetParseRowStrategiesList()
    {
        return new Dictionary<string, ParseRowStrategy>()
        {
            [TablesConstants.ReportTableTitle] = new ReportParseRowStrategy(),
            [TablesConstants.LevelRisksTableTitle] = new LevelRisksParseRowStrategy(),
            [TablesConstants.HostsTableTitle] = new HostsParseRowStrategy(),
            [TablesConstants.ProductsTableTitle] = new ProductsParseRowStrategy(),
            [TablesConstants.CriticalVulnerabilityTableTitle] = new VulnerabilityParseRowStrategy(),
            [TablesConstants.HighVulnerabilityTableTitle] = new VulnerabilityParseRowStrategy(),
            [TablesConstants.MediumVulnerabilityTableTitle] = new VulnerabilityParseRowStrategy(),
            [TablesConstants.LowVulnerabilityTableTitle] = new VulnerabilityParseRowStrategy(),
            [TablesConstants.VulnerabilityDescriptionTableTitle] = new VulnerabilityDescriptionParseRowStrategy(),
        };
    }
}
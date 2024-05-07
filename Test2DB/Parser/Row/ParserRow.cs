using ConsoleApp1.Constants.Tables;
using Test2DB.Models.Row;
using HtmlAgilityPack;

namespace ConsoleApp1.Parser;

public class ParserRow
{
    private static string _tableTitle = "";
    
    private static ParseRowStrategy _parseRowStrategy = new EmptyParseRowStrategy();
    
    /// <param name="parseRowStrategy"></param>
    public void SetParseRowStrategy(ParseRowStrategy parseRowStrategy)
    {
        _parseRowStrategy = parseRowStrategy;
    }

    /// <returns></returns>
    public ParseRowStrategy GetParseRowStrategy()
    {
        return _parseRowStrategy;
    }
    
    /// <param name="row"></param>
    /// <returns>RowModel</returns>
    public RowModel GetParsedRow(List<HtmlNode> tdList)
    {
        return _parseRowStrategy.GetParseRow(tdList);
    }
    
        /// <param name="tableTitle"></param>
    /// <returns>bool</returns>
    public static bool IsTableTitle(string tableTitle = "")
    {
        return TablesConstants.TableTitles.Contains(tableTitle);
    }
}
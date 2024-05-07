using System.Text.RegularExpressions;
using Test2DB.Models.Row;
using Test2DB.Models.Table;
using HtmlAgilityPack;

namespace ConsoleApp1.Parser;

public abstract class ParseRowStrategy
{
    /// <summary>
    ///  Метод парсинга строки
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    public abstract RowModel GetParseRow(List<HtmlNode> tdList);

    /// <returns>TableModel</returns>
    public abstract BaseTableModel GetTable();

    /// <param name="tdList"></param>
    /// <returns>string</returns>
    protected string GetPreparedString(List<HtmlNode> tdList)
    {
        string prepared = "";

        foreach (var td in tdList)
        {
            prepared += td.InnerText.Replace('\n', ' ');
        }
        
        return prepared.Replace("&nbsp;", " ").Replace("\r", " ").Replace("\t", " ").Trim();
    }
    
    protected string GetPreparedString(string text)
    {
        
        return text.Replace('\n', ' ').Replace("&nbsp;", " ").Replace("\r", " ").Replace("\t", " ").Trim();
    }
}
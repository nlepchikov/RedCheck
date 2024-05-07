using Test2DB.Models.Row;
using Test2DB.Models.Table;
using HtmlAgilityPack;

namespace ConsoleApp1.Parser;

public class HostsParseRowStrategy: ParseRowStrategy
{
    private readonly List<string> _blackListRowNames = new()
    {
        "Хост&nbsp;/&nbsp;Риск",
        "Всего"
    };
    
    public override RowModel GetParseRow(List<HtmlNode> tdList)
    {
        HostRowModel row = new HostRowModel();
        
        string rowName = tdList[1].InnerText.Trim();
        List<HtmlNode> tdStrList = tdList.Slice(2, tdList.Count - 2);

        if (_blackListRowNames.Contains(rowName))
        {
            return new EmptyRowModel();
        }
        
        row.Host = rowName;
        row.CriticalCount = Convert.ToInt32(GetPreparedString([tdStrList[0]]));
        row.HighCount = Convert.ToInt32(GetPreparedString([tdStrList[1]]));
        row.MediumCount = Convert.ToInt32(GetPreparedString([tdStrList[2]]));
        row.LowCount = Convert.ToInt32(GetPreparedString([tdStrList[3]]));
        
        return row;
    }

    public override BaseTableModel GetTable()
    {
        return new HostBaseTableModel();
    }
}
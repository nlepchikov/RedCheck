using Test2DB.Models.Row;
using Test2DB.Models.Table;
using HtmlAgilityPack;

namespace ConsoleApp1.Parser;

public class LevelRisksParseRowStrategy: ParseRowStrategy
{
    private readonly LevelRisksRowModel _levelRisksRowModel = new();

    public override RowModel GetParseRow(List<HtmlNode> tdList)
    {
        List<HtmlNode> tdStrList = tdList.Slice(3, tdList.Count - 3);

        int value;

        if (!int.TryParse(GetPreparedString(tdStrList), out value))
        {
            return _levelRisksRowModel;
        }
        
        string rowName = tdList[2].InnerText.Trim();

        setModelValueByRowName(rowName, value);
        
        return _levelRisksRowModel;
    }
    
    public override BaseTableModel GetTable()
    {
        return new LevelRisksBaseTableModel();
    }
    
    /// <param name="rowName"></param>
    /// <param name="value"></param>
    private void setModelValueByRowName(string rowName, int value)
    {
        switch (rowName)
        {
            case "Критический":
                _levelRisksRowModel.CriticalCount = value;
                break;
            case "Высокий":
                _levelRisksRowModel.HighCount = value;
                break;
            case "Средний":
                _levelRisksRowModel.MediumCount = value;
                break;
            case "Низкий":
                _levelRisksRowModel.LowCount = value;
                break;
        }
    }
}
using Test2DB.Models.Row;
using Test2DB.Models.Table;
using HtmlAgilityPack;

namespace ConsoleApp1.Parser;

public class EmptyParseRowStrategy : ParseRowStrategy
{
    public override RowModel GetParseRow(List<HtmlNode> tdList)
    {
        return new EmptyRowModel();
    }

    public override BaseTableModel GetTable()
    {
        return new EmptyBaseTableModel();
    }
}
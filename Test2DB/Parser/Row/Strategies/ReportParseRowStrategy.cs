using Test2DB.Models.Row;
using Test2DB.Models.Table;
using HtmlAgilityPack;

namespace ConsoleApp1.Parser;

public class ReportParseRowStrategy: ParseRowStrategy
{
    private RowModel _reportRowModel = new ReportRowModel();
    
    
    public override RowModel GetParseRow(List<HtmlNode> tdList)
    {
        List<HtmlNode> tdStrList = tdList.Slice(2, tdList.Count - 2);

        string value = GetPreparedString(tdStrList);
        string rowName = tdList[1].InnerText.Trim();

        if (rowName.Contains("Хосты"))
        {
            rowName = rowName.Split("&nbsp;")[0];
        }
        
        
        
        setModelValueByRowName(rowName, value);
        
        if (rowName.Contains("Хосты"))
        {
            RowModel newRowModel = _reportRowModel;
            _reportRowModel = new EmptyRowModel();
            return newRowModel;
        }
        
        return new EmptyRowModel();
    }
    
    public override BaseTableModel GetTable()
    {
        return new ReportBaseTableModel();
    }
    
    /// <param name="rowName"></param>
    /// <param name="value"></param>
    private void setModelValueByRowName(string rowName, string value)
    {
        ReportRowModel reportRowModel = null!;
        if (_reportRowModel is ReportRowModel)
        {
            reportRowModel = (ReportRowModel)_reportRowModel;
        }
        else
        {
            return;
        }
       
        switch (rowName)
        {
            case "№&nbsp;отчёта":
                reportRowModel.ReportNumber = value;

                break;
            case "Профиль":
                reportRowModel.Profile = value;

                break;
            case "Задания":
                reportRowModel.Tasks = value;

                break;
            case "Имя":
                reportRowModel.Name = value;
                
                break;
            case "Хосты":
                reportRowModel.Hosts = value;
                break;
            case "Начало/завершение&nbsp;сканирования":
                string startEndDate = value;
                string[] dateArray = startEndDate.Split('/');

                reportRowModel.StartScan = DateTime.Parse(dateArray[0].Trim());
                reportRowModel.EndScan = DateTime.Parse(dateArray[1].Trim());
                break;
            case "Формирование&nbsp;отчёта":
                string createDate = value;
                
                reportRowModel.ReportCreate = DateTime.Parse(createDate);

                break;
        }
    }
}
using System.Reflection;
using ConsoleApp1.Constants.Tables;
using ConsoleApp1.Fabrics;
using Test2DB.Models.Row;
using Test2DB.Models.Table;
using ConsoleApp1.Parser;
using HtmlAgilityPack;
using MimeKit;

namespace ConsoleApp1.ParserService
{
class ParserService
{
    private static bool _isVulnTable = false;

    public static async Task<Dictionary<string, BaseTableModel>> GetTables()
    {
		string path = "C:\\Users\\ilied\\Downloads\\ConsoleApp2\\ConsoleApp1\\test.mht";
        
        ParserRow parserRow = new ParserRow(); // Парсер для строк
        Dictionary<string, BaseTableModel> tableDictionary = new Dictionary<string, BaseTableModel>(); // Модели будут собираться тут
        string lastTableName = "";
        
        parserRow.SetParseRowStrategy(new EmptyParseRowStrategy());

        using (FileStream fstream = File.OpenRead(path))
        {
            MimeMessage message = MimeMessage.Load(fstream);
            
            foreach (TextPart textPart in message.BodyParts.OfType<TextPart>().Where(tp => tp.IsHtml))
            {
                string htmlText = textPart.Text;
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlText);

                var htmlTrList = htmlDocument.DocumentNode.SelectNodes("//table/tr");

                foreach (var tr in htmlTrList)
                {
                    if (tr == null)
                    {
                        continue;
                    }

                    List<HtmlNode> tdList = tr.Elements("td").ToList();
                    string rowText = string.Join("", tr.InnerText.Split("\t")).Trim();
                    
                    if (!_isVulnTable && rowText.Length == 0 || (tdList.Count > 6 && int.TryParse(rowText, out _)))
                    {
                        continue;
                    }
                    
                    bool isTableTitle = ParserRow.IsTableTitle(rowText);

                    if (isTableTitle)
                    {
                        parserRow.SetParseRowStrategy(ParserStrategyFabric.GetByTableName(rowText)); // По названию таблицы получаем стратегию парсинга

                        if (!tableDictionary.ContainsKey(rowText) && parserRow.GetParseRowStrategy().GetTable() != null)
                        {
                            tableDictionary[rowText] = parserRow.GetParseRowStrategy().GetTable();
                        }

                        lastTableName = rowText;

                        if (!_isVulnTable && TablesConstants.VulnTablesTitles.Contains(rowText))
                        {
                            _isVulnTable = true;
                        }
                        
                        continue;
                    }

                    RowModel row = parserRow.GetParsedRow(tdList);
                    
                    if (row.IsEmpty())
                    {
                        continue;
                    }
                    
                    BaseTableModel baseTableModel = new EmptyBaseTableModel();
                    
                    if (tableDictionary.ContainsKey(lastTableName))
                    {
                        baseTableModel = tableDictionary[lastTableName];
                    }

                    baseTableModel.SetRow(row);
                } 
            }
        }
        
        return tableDictionary;
    }

    static public void printRow(RowModel row)
    {
        List<PropertyInfo> props = row.GetType().GetProperties().ToList();
        var propsTest = row.GetType().GetProperties().ToArray();

        foreach (var prop in props)
        {
            var value = prop.GetValue(row, null);

            if (prop.Name == "Entities")
            {
                foreach (KeyValuePair<string, List<string>> item in (IEnumerable<KeyValuePair<string, List<string>>>)value)
                {
                    foreach (var v in item.Value)
                    {
                        Console.WriteLine($"{prop.Name} -> {item.Key} {v}");
                    }
                }
                
                continue;
            } 
            
            if (prop.Name == "Links")
            {
                foreach (KeyValuePair<string, List<string>> item in (IEnumerable<KeyValuePair<string, List<string>>>)value)
                {
                    Console.WriteLine($"{prop.Name} -> {item.Key}");

                    foreach (var v in item.Value)
                    {
                        Console.WriteLine($"{prop.Name} -> {item.Key} {v}");
                    }
                }
                
                // continue;
            } 
            
            Console.WriteLine($"{prop.Name}: {value}");
        }
    } 
}
}

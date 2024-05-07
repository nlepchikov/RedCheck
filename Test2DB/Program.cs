using ConsoleApp1.Constants.Tables;
using ConsoleApp1.ParserService;
using Test2DB.Models.Row;
using Test2DB.Models.Table;
using Test2DB.Context;
using Test2DB.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/parser", async () =>
{

});

app.UseHttpsRedirection();

ScanerVSContext db = new ScanerVSContext();

Dictionary<string, BaseTableModel> tableList = await ParserService.GetTables();

foreach (KeyValuePair<string, BaseTableModel> tableValuePair in tableList)
{
    string tableType = tableValuePair.Key;
    BaseTableModel table = tableValuePair.Value;
    
    foreach (RowModel row in table.GetRows())
    {
        if (tableType == TablesConstants.HostsTableTitle)
        {
            HostModel host = new();
            HostRowModel hostRow = (HostRowModel)row;

            host.Host = hostRow.Host;
            host.CriticalCount = hostRow.CriticalCount;
            host.HighCount = hostRow.HighCount;
            host.MediumCount = hostRow.MediumCount;
            host.LowCount = hostRow.LowCount;

            db.HostModel.Add(host);
        }
        
        if (tableType == TablesConstants.ProductsTableTitle)
        {
            ProductModel product = new();
            ProductsRowModel productRow = (ProductsRowModel)row;
            
            product.Product = productRow.Product;
            product.CriticalCount = productRow.CriticalCount;
            product.HighCount = productRow.HighCount;
            product.MediumCount = productRow.MediumCount;
            product.LowCount = productRow.LowCount;
            
            db.ProductModel.Add(product);
        }
    
        if (tableType == TablesConstants.CriticalVulnerabilityTableTitle || 
            tableType == TablesConstants.HighVulnerabilityTableTitle || 
            tableType == TablesConstants.MediumVulnerabilityTableTitle ||
            tableType == TablesConstants.LowVulnerabilityTableTitle)
        {
            VulnerabilityModel vulnerability = new();
            VulnerabilityRowModel vulnerabilityRow = (VulnerabilityRowModel )row;

            vulnerability.Host = vulnerabilityRow.Host;
            vulnerability.ALTXId = vulnerabilityRow.ALTXId;
            vulnerability.LevelTypeId = vulnerabilityRow.LevelTypeId;
            vulnerability.Name = vulnerabilityRow.Name;
            
            db.VulnerabilityModel.Add(vulnerability);

        }

        if (tableType == TablesConstants.ReportTableTitle)
        {
            ReportModel report = new();
            ReportRowModel reportRow = (ReportRowModel)row;

            report.ReportNumber = reportRow.ReportNumber;
            report.Tasks = reportRow.Tasks;
            report.StartScan = reportRow.StartScan.ToUniversalTime();
            report.EndScan = reportRow.EndScan.ToUniversalTime();
            report.ReportCreate = reportRow.ReportCreate.ToUniversalTime();
            report.Name = reportRow.Name;
            report.Hosts = reportRow.Hosts;
            
            db.ReportModel.Add(report);
        }

        if (tableType == TablesConstants.VulnerabilityDescriptionTableTitle)
        {
            VulnerabilityDescriptionModel descriptionModel = new();
            VulnerabilityDescriptionRowModel descriptionRowModel = (VulnerabilityDescriptionRowModel)row;

            descriptionModel.LevelTypeId = descriptionRowModel.LevelTypeId;
            descriptionModel.ALTXId = descriptionRowModel.ALTXId;
            descriptionModel.Name = descriptionRowModel.Name;
            descriptionModel.Description = descriptionRowModel.Description;
            descriptionModel.Correction = descriptionRowModel.Correction;
            
            db.VulnerabilityDescriptionModel.Add(descriptionModel);
        }
        
        
    }
}

db.SaveChanges();

app.Run();

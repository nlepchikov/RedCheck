using Microsoft.EntityFrameworkCore;
using Test2DB.Models;

namespace Test2DB.Context;

public class ScanerVSContext : DbContext
{
    
    public DbSet<HostModel> HostModel { get; set; }
    public DbSet<ProductModel> ProductModel { get; set; }
    public DbSet<ReportModel> ReportModel { get; set; }
    public DbSet<VulnerabilityModel> VulnerabilityModel { get; set; }
    public DbSet<VulnerabilityDescriptionModel> VulnerabilityDescriptionModel { get; set; }
    
    
    public ScanerVSContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234");
    }
}
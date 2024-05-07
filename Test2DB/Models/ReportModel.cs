using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2DB.Models
{
    [Table("report")]
    public class ReportModel
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Column("reportNumber")]
        public string ReportNumber { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("hosts")]
        public string Hosts { get; set; }
        [Column("tasks")]
        public string Tasks { get; set; }
        [Column("startScan")]
        public DateTime StartScan { get; set; }
        [Column("endScan")]
        public DateTime EndScan { get; set; }
        [Column("reportCreate")]
        public DateTime ReportCreate { get; set; }
        
        
        //public string Profile { get; set; }
    }
}
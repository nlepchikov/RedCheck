using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2DB.Models
{
    [Table("product")]
    public class ProductModel
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Column("criticalCount")]
        public int CriticalCount { get; set; }
        [Column("highCount")]
        public int HighCount { get; set; }
        [Column("mediumCount")]
        public int MediumCount { get; set; }
        [Column("lowCount")]
        public int LowCount { get; set; }
        [Column("product")]
        public string Product { get; set; }
    }
}
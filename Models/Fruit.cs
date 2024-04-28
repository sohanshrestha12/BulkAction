using FruitApp.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitApp.Models
{
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public FruitSeasonEnum Season { get; set; }
        public FruitCategoryEnum Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}

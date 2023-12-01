using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComponentRepair.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        [DisplayName("Price")]
        [Range(0, int.MaxValue, ErrorMessage ="Must be positive value")]
        public int Price { get; set; }

    }
}

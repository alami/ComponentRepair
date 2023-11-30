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
        public int Price { get; set; }

    }
}

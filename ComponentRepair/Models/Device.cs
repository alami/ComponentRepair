using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComponentRepair.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        [DisplayName("Price In")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive value")]
        public int Pricein { get; set; }
        [DisplayName("Price Result (Calculate)")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive value")]
        public int Pricerezult { get; set; }


    }
}

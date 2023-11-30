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
        public int Pricein { get; set; }
        [DisplayName("Price Result (Calculate)")]
        public int Pricerezult { get; set; }


    }
}

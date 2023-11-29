using System.ComponentModel.DataAnnotations;

namespace ComponentRepair.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Pricein { get; set; }
        public int Pricerezult { get; set; }


    }
}

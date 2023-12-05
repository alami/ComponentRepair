namespace ComponentRepair.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}

namespace ComponentRepair.Models.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Product = new Product();
        }
        
        public Product Product { get; set; }
        public bool ExistsInSell { get; set; }
    }

}

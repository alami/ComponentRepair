using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComponentRepair.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem>? DeviceSelectList { get; set; }
        public IEnumerable<SelectListItem>? ComponentSelectList { get; set; }
    }
}

using System;

namespace INVEON.Dtos.ViewModels
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

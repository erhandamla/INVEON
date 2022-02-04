using System;
using System.ComponentModel.DataAnnotations;

namespace INVEON.Dtos.ViewModels
{
    public class ProductInsertViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Barkod")]
        public string Barcode { get; set; }

        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Stok Adedi")]
        public int Instock { get; set; }

        [Display(Name = "Görsel")]
        public byte[] Image { get; set; }

        [Display(Name = "Aktif Mi")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        //public DateTime? UpdatedDate { get; set; }
    }
}

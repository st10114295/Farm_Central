using Farm_Central.Models.DBEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_Central.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }

        [DisplayName("Price of The Product")]
        public double ProductPrice { get; set; }

        [DisplayName("Manufactured Date")]
        public DateTime DateManufactured { get; set; }

        [DisplayName("Farmers Full Name")]
        public string FarmerName { get; set; }
    }
}

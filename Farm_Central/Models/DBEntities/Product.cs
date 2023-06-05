using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Farm_Central.Models.DBEntities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FarmerName { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string ProductName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ProductDescription { get; set; }

      
        public double ProductPrice { get; set; }
        public DateTime DateManufactured { get; set; }

        
        
    }
}

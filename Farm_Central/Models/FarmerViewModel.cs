using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_Central.Models
{
    public class FarmerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Contact Number")]
        public string ContactNum { get; set; }
    }
}

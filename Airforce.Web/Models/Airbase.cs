using Alesik.Haidov.Airforce.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alesik.Haidov.Airforce.Web.Models
{
    [Table("Airbases")]
    public class Airbase : IAirbase
    {
        [Key]
        public string GUID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
    }
}

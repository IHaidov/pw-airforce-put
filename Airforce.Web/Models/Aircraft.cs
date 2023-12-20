using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alesik.Haidov.Airforce.Web.Models
{
    [Table("Aircrafts")]
    public class Aircraft : IAircraft
    {
        [Key]
        public string GUID { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Range(0, int.MaxValue)]
        public int ServiceHours { get; set; }

        [Required]
        public AircraftType Type { get; set; }

        [ForeignKey("Airbase.GUID")]
        public IAirbase Airbase { get; set; }
    }
}

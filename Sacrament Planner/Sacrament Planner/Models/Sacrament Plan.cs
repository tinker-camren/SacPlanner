using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sacrament_Planner.Models
{
    public class Sacrament_Plan
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Conducting")]
        public string ConductingLeader { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Opening Song")]
        public string OpeningSong { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Sacrament Hmyn")]
        public string SacramentHymn { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Closing Song")]
        public string ClosingSong { get; set; }
        [StringLength(100)]
        [Display(Name = "Musical Number")]
        public string MusicalNumber { get; set; }
        [StringLength(50)]
        [Display(Name = "Intermediate Hymn")]
        public string IntermediateHymn { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayer { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayer { get; set; }
        public int NumberOfSpeakers { get; set; }
        public List<Speaker> speakers = new List<Speaker>(5);
        public List<Speaker> Speakers { get; set; }

    }
}

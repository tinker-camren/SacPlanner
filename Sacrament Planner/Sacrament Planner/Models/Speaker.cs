using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sacrament_Planner.Models
{
    public class Speaker
    {
        public int ID { get; set; }

        public int Sacrament_PlanID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
    }
}

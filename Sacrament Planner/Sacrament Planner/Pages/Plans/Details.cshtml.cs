using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sacrament_Planner.Models;

namespace Sacrament_Planner.Pages.Plans
{
    public class DetailsModel : PageModel
    {
        private readonly Sacrament_Planner.Models.Sacrament_PlannerContext _context;

        public DetailsModel(Sacrament_Planner.Models.Sacrament_PlannerContext context)
        {
            _context = context;
        }

        public Sacrament_Plan Sacrament_Plan { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
        public int SacramentPlanID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SacramentPlanID = id.Value;
            Speakers = _context.Speaker.Where(s => s.Sacrament_PlanID == id);
            Sacrament_Plan = await _context.Sacrament_Plan.FirstOrDefaultAsync(m => m.ID == id);

            if (Sacrament_Plan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

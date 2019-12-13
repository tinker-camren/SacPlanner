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
    public class IndexModel : PageModel
    {
        private readonly Sacrament_Planner.Models.Sacrament_PlannerContext _context;

        public IndexModel(Sacrament_Planner.Models.Sacrament_PlannerContext context)
        {
            _context = context;
        }

        public IList<Sacrament_Plan> Sacrament_Plan { get;set; }

        public async Task OnGetAsync()
        {
            Sacrament_Plan = await _context.Sacrament_Plan.ToListAsync();
        }
    }
}

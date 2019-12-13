using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sacrament_Planner.Models;

namespace Sacrament_Planner.Pages.Speakers
{
    public class IndexModel : PageModel
    {
        private readonly Sacrament_Planner.Models.Sacrament_PlannerContext _context;

        public IndexModel(Sacrament_Planner.Models.Sacrament_PlannerContext context)
        {
            _context = context;
        }

        public IList<Speaker> Speaker { get;set; }

        public async Task OnGetAsync()
        {
            Speaker = await _context.Speaker.ToListAsync();
        }
    }
}

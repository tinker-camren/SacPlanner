using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sacrament_Planner.Models;

namespace Sacrament_Planner.Pages.Plans
{
    public class CreateModel : PageModel
    {
        private readonly Sacrament_Planner.Models.Sacrament_PlannerContext _context;

        public CreateModel(Sacrament_Planner.Models.Sacrament_PlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sacrament_Plan Sacrament_Plan { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //for (var i = 0; i <= Sacrament_Plan.NumberOfSpeakers; i++)
            //{
            //    Speaker speaker = new Speaker();
            //    speaker.Name
            //}

            _context.Sacrament_Plan.Add(Sacrament_Plan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

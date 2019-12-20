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

            //Start nonsense

            //Added this nonsense so that I could remove the [Required]
            //parameter from the Speaker model class so that the hidden 
            //divs don't throw exceptions on post. This prevents
            //null values from going into the speaker table

            List<Speaker> speakers = new List<Speaker>();

            for (int i = 0; i < 5; i++)
            {
                if (Sacrament_Plan.Speakers[i].Name != null && Sacrament_Plan.Speakers[i].Subject != null)
                {
                    speakers.Add(Sacrament_Plan.Speakers[i]);
                }
            }

            Sacrament_Plan.Speakers = speakers;

            //End nonsense

            _context.Sacrament_Plan.Add(Sacrament_Plan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sacrament_Planner.Models;

namespace Sacrament_Planner.Pages.Plans
{
    public class EditModel : PageModel
    {
        private readonly Sacrament_Planner.Models.Sacrament_PlannerContext _context;

        public EditModel(Sacrament_Planner.Models.Sacrament_PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sacrament_Plan Sacrament_Plan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //ISpeakers = _context.Speaker.Where(s => s.Sacrament_PlanID == id);
            Sacrament_Plan = await _context.Sacrament_Plan
                .Include(p => p.Speakers).FirstOrDefaultAsync(m => m.ID == id);           

            if (Sacrament_Plan == null)
            {
                return NotFound();
            }            
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Start nonsense

            // Added this so that null values aren't entered into the table. Had to add it here and remove
            // it from the model so that things don't break

            var planToUpdate = await _context.Sacrament_Plan.FindAsync(id);
            

            List<Speaker> speakers = new List<Speaker>();

            for (int i = 0; i < Sacrament_Plan.Speakers.Count; i++)
            {
                if (Sacrament_Plan.Speakers[i].Name != null && Sacrament_Plan.Speakers[i].Subject != null)
                {
                    speakers.Add(Sacrament_Plan.Speakers[i]);
                }
            }

            // If i don't do it this way, it gives some tracking DB error
            planToUpdate.Speakers = speakers;
            planToUpdate.ClosingPrayer = Sacrament_Plan.ClosingPrayer;
            planToUpdate.ClosingSong = Sacrament_Plan.ClosingSong;
            planToUpdate.ConductingLeader = Sacrament_Plan.ConductingLeader;
            planToUpdate.IntermediateHymn = Sacrament_Plan.IntermediateHymn;
            planToUpdate.MeetingDate = Sacrament_Plan.MeetingDate;
            planToUpdate.MusicalNumber = Sacrament_Plan.MusicalNumber;
            planToUpdate.OpeningPrayer = Sacrament_Plan.OpeningPrayer;
            planToUpdate.OpeningSong = Sacrament_Plan.OpeningSong;
            planToUpdate.SacramentHymn = Sacrament_Plan.SacramentHymn;


            //End nonsense

            _context.Attach(planToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sacrament_PlanExists(Sacrament_Plan.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Sacrament_PlanExists(int id)
        {
            return _context.Sacrament_Plan.Any(e => e.ID == id);
        }
    }
}

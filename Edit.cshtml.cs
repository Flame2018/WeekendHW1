using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeekendHW.Data;

namespace WeekendHW.Pages.myAssociation
{
    public class EditModel : PageModel
    {
        private readonly WeekendHW.Data.ApplicationDbContext _context;

        public EditModel(WeekendHW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HAssociation HAssociation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HAssociation = await _context.HAssociation.FirstOrDefaultAsync(m => m.HAID == id);

            if (HAssociation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HAssociation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HAssociationExists(HAssociation.HAID))
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

        private bool HAssociationExists(int id)
        {
            return _context.HAssociation.Any(e => e.HAID == id);
        }
    }
}

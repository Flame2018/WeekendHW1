using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeekendHW.Data;


namespace WeekendHW.Pages.myAssociation
{
    [Authorize(Roles = "headhunter")]
    public class IndexModel : PageModel
    {
        private readonly WeekendHW.Data.ApplicationDbContext _context;

        [BindProperty]
        public int OpenCount { get; set; }

        [BindProperty]
        public int ClosedCount { get; set; }

        public IndexModel(WeekendHW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<HAssociation> HAssociation { get;set; }

        public async Task OnGetAsync()
        {
            HAssociation = await _context.HAssociation.ToListAsync();

            foreach(var item in HAssociation)
            {
                if(item.ApprPos == false)
                {
                    OpenCount += 1;
                }else if (item.ApprPos == false)
                {
                    ClosedCount += 1;
                }
                else
                {

                }
            }
        }
    }
}

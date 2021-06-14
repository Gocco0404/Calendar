using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calender.DBAccess;
using Calender.Models;

namespace Calender.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Calender.DBAccess.DBAccessContext _context;

        public DetailsModel(Calender.DBAccess.DBAccessContext context)
        {
            _context = context;
        }

        public TaskInfo TaskInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskInfo = await _context.DBAccess.FirstOrDefaultAsync(m => m.ID == id);

            if (TaskInfo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

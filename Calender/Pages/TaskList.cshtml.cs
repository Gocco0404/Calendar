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
    public class TaskListModel : PageModel
    {
        private readonly Calender.DBAccess.DBAccessContext _context;

        public TaskListModel(Calender.DBAccess.DBAccessContext context)
        {
            _context = context;
        }

        public IList<TaskInfo> TaskInfo { get;set; }

        public async Task OnGetAsync()
        {
            TaskInfo = await _context.DBAccess.ToListAsync();
        }
    }
}

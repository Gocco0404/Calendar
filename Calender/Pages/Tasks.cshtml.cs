using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calender.Pages
{
    public class TasksModel : PageModel
    {
        public void OnGet(string thisMonth, string thisDay)
        {
            string tmp = thisMonth;
            string tmp2 = thisDay;
        }
    }
}
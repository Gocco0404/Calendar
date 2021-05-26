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
        public DateTime DateValue { get; set; }
        public void OnGet(DateTime thisMonth, string thisDay)
        {
            DateValue = new DateTime(thisMonth.Year, thisMonth.Month, Int32.Parse(thisDay));
        }
    }
}
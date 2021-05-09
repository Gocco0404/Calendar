using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calender.Pages
{
    public class ButtomResultModel : PageModel
    {
        public string Message { get; set; }
        public DateTime DayStart { get; set; }
        public int[] Month { get; set; }

        public void OnGet()
        {
            DateTime dNow = System.DateTime.Now;
            int MonthCount = 42;
            int MonthLastDay = DateTime.DaysInMonth(dNow.Year, dNow.Month - 1);
            Message = dNow.Month - 1 + "ŒŽ";
            DayStart = new DateTime(dNow.Year, dNow.Month - 1, 1);
            int Difference = -1;
            Month = new int[MonthCount];
            for (int i = 0; i < MonthCount; i++)
            {
                if (i < (int)DayStart.DayOfWeek)
                {
                    Month[i] = 0;
                    Difference++;
                }
                else if (i - Difference <= MonthLastDay)
                {
                    Month[i] = i - Difference;
                }
                else
                {
                    Month[i] = 0;
                }
            }
        }
        public IActionResult OnPost()
        {
            return Redirect("/ButtonComplete");
        }
    }
}

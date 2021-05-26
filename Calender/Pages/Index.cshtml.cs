using Calender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Calender.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Message { get; set; }
        public DateTime DayStart { get; set; }
        public DateTime ThisMonth { get; set; }
        public DateTime DispMonth { get; set; }
        public int[] Month { get; set;}
        private int MonthCount = 42;

        [BindProperty]
        public MonthInfo monthInfo { get; set; }

        public void OnGet()
        {
            DispMonth = System.DateTime.Now;
            int MonthLastDay = DateTime.DaysInMonth(DispMonth.Year, DispMonth.Month);
            Message = DispMonth.Year + "年" + DispMonth.Month  +"月";
            DayStart = new DateTime(DispMonth.Year, DispMonth.Month, 1);
            Month = new int[MonthCount];
            Month = SetCalenderValue(DayStart);
        }

        public void OnGetPrevMonth(string prevMonth)
        {
            ThisMonth = DateTime.Parse(prevMonth).AddMonths(-1);
            DispMonth = new DateTime(ThisMonth.Year, ThisMonth.Month, 1);
            int MonthLastDay = DateTime.DaysInMonth(DispMonth.Year, DispMonth.Month);
            Message = DispMonth.Year + "年" + DispMonth.Month + "月";
            Month = new int[MonthCount];
            Month = SetCalenderValue(DispMonth);
        }


        public void OnGetNextMonth(string nextMonth)
        {
            ThisMonth = DateTime.Parse(nextMonth).AddMonths(1);
            DispMonth = new DateTime(ThisMonth.Year,ThisMonth.Month,1);
            int MonthLastDay = DateTime.DaysInMonth(DispMonth.Year, DispMonth.Month);
            Message = DispMonth.Year + "年" + DispMonth.Month + "月";
            Month = SetCalenderValue(DispMonth);
        }

        public IActionResult OnPostPrev()
        {
            return RedirectToPage("/Index","prevmonth",new { prevMonth = monthInfo.prevMonth});
        }
        public IActionResult OnPostNext()
        {
            return RedirectToPage("/Index", "nextmonth", new { nextMonth = monthInfo.nextMonth });
        }
        public IActionResult OnPostTasks()
        {
            return RedirectToPage("/Tasks", new { thisMonth = monthInfo.thisMonth, thisDay = monthInfo.thisDay });
        }


        private int[] SetCalenderValue(DateTime dispMonth)
        {
            int Difference = -1;
            Month = new int[MonthCount];
            int MonthLastDay = DateTime.DaysInMonth(dispMonth.Year, dispMonth.Month);

            for (int i = 0; i < MonthCount; i++)
            {
                if (i < (int)dispMonth.DayOfWeek)
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
            return Month;
        }
    }
}

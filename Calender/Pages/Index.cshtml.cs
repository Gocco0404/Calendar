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
        public int[] Month { get; set;}

        public DateTime dNow = System.DateTime.Now;
        int MonthCount = 42;
        int h = 0;

        public void OnGet()
        {
            int MonthLastDay = DateTime.DaysInMonth(dNow.Year, dNow.Month);
            Message =  dNow.Month - h  +"月";
            DayStart = new DateTime(dNow.Year, dNow.Month - h, 1);
            int Difference = -1;
            Month = new int[MonthCount];
            for (int i = 0;i < MonthCount;i++)
            {
                if(i < (int)DayStart.DayOfWeek)
                {
                    Month[i] = 0;
                    Difference++;
                }
                else if(i - Difference <= MonthLastDay)
                {
                    Month[i] = i - Difference;
                }
                else
                {
                    Month[i] = 0;
                }
            }
        }
    }
}

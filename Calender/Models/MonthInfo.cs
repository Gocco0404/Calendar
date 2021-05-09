using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calender.Models
{
    public class MonthInfo
    {
        public string prevMonth { get; set; }
        public string nextMonth { get; set; }
        public string thisMonth { get; set; }
        public string thisDay { get; set; }
    }
}

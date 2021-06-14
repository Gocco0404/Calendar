using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calender.Models
{
    public class TaskInfo
    {
        public int ID { set; get; }
        public string taskName { set; get; }
        public string taskContents { set; get; }
        public DateTime taskDate { set; get; }
        public DateTime updateDate { set; get; }
    }
}

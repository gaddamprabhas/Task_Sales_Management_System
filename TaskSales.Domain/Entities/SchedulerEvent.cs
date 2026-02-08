using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSales.Domain.Entities
{
    public class SchedulerEvent
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}

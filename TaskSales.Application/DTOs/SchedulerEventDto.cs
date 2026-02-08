using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSales.Application.DTOs
{
    public class SchedulerEventDto
    {
        public int Id { get; set; }

        // 🔹 Your real stored title
        public string Title { get; set; } = string.Empty;

        // 🔹 REQUIRED by Syncfusion popup editor
        // 🔹 Maps Subject ↔ Title automatically
        public string Subject
        {
            get => Title;
            set => Title = value;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

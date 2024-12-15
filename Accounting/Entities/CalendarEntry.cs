using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Entities
{
    public class CalendarEntry
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public virtual List<Kid>? Kids { get; set; }
    }
}

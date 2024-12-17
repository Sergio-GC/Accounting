using System.ComponentModel.DataAnnotations;

namespace Accounting.Entities
{
    public class CalendarEntry
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }


        // Many-to-Many relationship: Calendar entries linked to kids
        public virtual ICollection<Kid>? Kids { get; set; }
    }
}

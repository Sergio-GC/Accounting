using System.ComponentModel.DataAnnotations;

namespace Accounting.Entities
{
    public class Kid
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        // Many-to-Many relationship: Self-referencing relationship for siblings
        public virtual ICollection<Kid>? Siblings { get; set; }
        public virtual ICollection<Kid>? SiblingOf { get; set; }


        // Many-to-Many relationship: Kids participating in calendar entries
        public virtual ICollection<CalendarEntry>? CalendarEntries { get; set; }
    }
}
using Accounting;
using Accounting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBLL.CalendarHandlers
{
    public class CalendarEntryManager
    {
        private AccountingContext _ctx;

        public CalendarEntryManager(AccountingContext ctx)
        {
            _ctx = ctx;
        }

        public List<CalendarEntry> GetAllCalendarEntries()
        {
            return _ctx.CalendarEntries.ToList();
        }

        public List<CalendarEntry> GetFutureCalendarEntries()
        {
            return _ctx.CalendarEntries.Where(ce => ce.Date >=  DateTime.Now).ToList();
        }

        public List<CalendarEntry> GetPastCalendarEntries()
        {
            return _ctx.CalendarEntries.Where(ce => ce.Date < DateTime.Now).ToList();
        }

        public void AddCalendarEntry(CalendarEntry calendarEntry) 
        {
            _ctx.CalendarEntries.Add(calendarEntry);
            _ctx.SaveChanges();
        }

        public void UpdateCalendarEntry(CalendarEntry calendarEntry)
        {
            CalendarEntry OldEntry = _ctx.CalendarEntries.Where(ce => ce.Id ==  calendarEntry.Id).Single();
            OldEntry = calendarEntry;

            _ctx.SaveChanges();
        }

        public void RemoveCalendarEntry(CalendarEntry calendarEntry)
        {
            _ctx.CalendarEntries.Remove(calendarEntry);
            _ctx.SaveChanges();
        }
    }
}

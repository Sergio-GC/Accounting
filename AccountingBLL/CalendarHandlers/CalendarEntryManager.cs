using Accounting;
using Accounting.Entities;

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

        public List<CalendarEntry> GetNextEntries()
        {
            DateTime StartDate = DateTime.Now.AddDays(-1);
            DateTime EndDate = DateTime.Now.AddDays(6);

            return _ctx.CalendarEntries.Where(ce => ce.Date > StartDate && ce.Date <= EndDate).ToList();
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


        public List<Result> GetResultForMonth(DateTime Month)
        {
            // Get the affected entries
            List<CalendarEntry> ces = _ctx.CalendarEntries.Where(ce => ce.Date.Month.Equals(Month.Month)).ToList();

            // Build the results
            List<Result> result = new List<Result>();
            foreach (CalendarEntry ce in ces)
            {
                foreach(Kid k in ce.Kids)
                {
                    result.Add(new Result { Date = ce.Date, Kid = k, Value = ((decimal)(ce.Departure - ce.Arrival).TotalHours) * ce.Price.Value });
                }
            }

            return result;
        }

        public List<Result> GetResultForKid(Kid kid) 
        {
            // Get the affected entries
            List<CalendarEntry> ces = _ctx.CalendarEntries.Where(ce => ce.Kids.Contains(kid)).ToList();

            List<Result > result = new List<Result>();
            foreach (CalendarEntry ce in ces) 
            {
                foreach (Kid k in ce.Kids)
                {
                    if (k.Id != kid.Id)
                        continue;

                    result.Add(new Result { Date = ce.Date, Kid = k, Value = ((decimal)(ce.Departure - ce.Arrival).TotalHours) * ce.Price.Value });
                }
            }

            return result;
        }
    }
}

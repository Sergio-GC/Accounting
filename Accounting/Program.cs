using Accounting.Entities;

namespace Accounting
{
    public class Program
    {
        static AccountingContext ctx;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ctx = new AccountingContext();

            // Initialize db
            if (ctx.Database.EnsureCreated())
            {
                Console.WriteLine("Database has been created!");
                InitDb();
            }
            else
            {
                Console.WriteLine("Database exists already"); 
            }

            Console.WriteLine("Done!");
        }

        #region Database initialization
        private static void InitDb()
        {
            Console.WriteLine("Writing data...");

            Kid Carolina = new Kid() { Name = "Carolina"};
            Kid Leticia = new Kid() { Name = "Leticia" };
            Kid Gabi = new Kid() { Name = "Gabi" };

            ctx.Kids.Add(Carolina);
            ctx.Kids.Add(Leticia);
            ctx.Kids.Add(Gabi);

            ctx.SaveChanges();

            Kid k = ctx.Kids.Where(k => k.Name == "Carolina").First();
            Kid i = ctx.Kids.Where(i => i.Name == "Leticia").First();

            if(k.Siblings == null)
            {
                k.Siblings = new List<Kid>();
                k.SiblingOf = new List<Kid>();
            }

            if(i.Siblings == null)
            {
                i.Siblings = new List<Kid>();
                i.SiblingOf = new List<Kid>();

            }

            k.Siblings.Add(i);
            k.SiblingOf.Add(i);
            i.SiblingOf.Add(k);
            i.Siblings.Add(k);

            ctx.SaveChanges();

            List<Kid> Kids1 = new List<Kid>() { Carolina, Leticia};

            DateTime Date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);
            DateTime Date11 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 30, 0);
            DateTime Date2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            DateTime Date3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 15, 0);
            DateTime Date31 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 18, 45, 0);

            ctx.CalendarEntries.Add(new CalendarEntry() { Kids = Kids1, Date = DateTime.Today, Arrival = Date1, Departure = Date11});
            ctx.CalendarEntries.Add(new CalendarEntry() { Kids = new List<Kid>() { Carolina }, Date = DateTime.Today.AddDays(1), Arrival = Date2, Departure = Date11 });
            ctx.CalendarEntries.Add(new CalendarEntry() { Kids = new List<Kid>() { Gabi }, Date = DateTime.Today.AddDays(1), Arrival = Date3, Departure = Date31 });

            ctx.SaveChanges();
        }
        #endregion
    }
}

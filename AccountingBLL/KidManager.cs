using Accounting;
using Accounting.Entities;

namespace AccountingBLL
{
    public class KidManager : IKidManager
    {
        private AccountingContext _ctx;

        public KidManager(AccountingContext ctx)
        {
            _ctx = ctx;
        }

        public List<Kid> GetKids()
        {
            return _ctx.Kids.ToList();
        }

        public void UpdateKid(Kid kid)
        {
            Kid OldKid = _ctx.Kids.Where(k => k.Id == kid.Id).Single();
            OldKid = kid;

            _ctx.SaveChanges();
        }

        public void AddKid(Kid kid)
        {
            _ctx.Kids.Add(kid);
            _ctx.SaveChanges();
        }

        public void RemoveKid(Kid kid)
        {
            _ctx.Kids.Remove(kid);
            _ctx.SaveChanges();
        }

    }
}

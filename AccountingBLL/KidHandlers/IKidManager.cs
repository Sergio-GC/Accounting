using Accounting.Entities;

namespace AccountingBLL.KidHandlers
{
    public interface IKidManager
    {
        void AddKid(Kid kid);
        List<Kid> GetKids();
        void RemoveKid(Kid kid);
        void UpdateKid(Kid kid);
    }
}
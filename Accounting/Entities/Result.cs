namespace Accounting.Entities
{
    public class Result
    {
        public DateTime Date {  get; set; }
        public virtual Kid? Kid { get; set; }
        public decimal Value { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Accounting.Entities
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Label {  get; set; }
        public bool IsDefault {  get; set; }
    }
}

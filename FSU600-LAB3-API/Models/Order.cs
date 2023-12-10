namespace FSU600_LAB3_API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
    }
}

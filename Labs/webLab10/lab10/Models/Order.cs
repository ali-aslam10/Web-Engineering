namespace lab10.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<int> prodId { get; set; }
        public string createdat { get; set; }
        public decimal amount { get; set; }

    }
}

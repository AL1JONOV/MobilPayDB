namespace MobilPayDemo.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Balance { get; set; }
    }
}

namespace MobilPayDemo.Entities
{
    public class CardToUser
    {

        public Card Card { get; set; }
        public Guid CardId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}

using MobilPayDemo.Data;
using MobilPayDemo.Entities;

namespace MobilPay
{
    public class Program
    {
        static void Main(string[] args)
        {
            var user = new User()
            {
                Birthday = DateTime.UtcNow,
                FirstName = "Jumavoy2",
                LastName = "Payshanbiyev",
                Id = Guid.NewGuid()
            };

            var card = new Card()
            {
                Id = Guid.NewGuid(),
                Balance = 30000000,
                CardNumber = "9860030145657751",
                CreateDate = DateTime.UtcNow,
                Expiry = "1225"
            };

            var cardToUser = new CardToUser()
            {
                CardId = card.Id,
                UserId = user.Id,
            };

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Users.Add(user);
                context.Cards.Add(card);
                context.SaveChanges();

                context.CardToUsers.Add(cardToUser);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                var users = from u in context.Users
                            where u.Id == user.Id
                            select new
                            {
                                u.Id,
                                u.FirstName,
                                u.LastName,
                            };
                Console.WriteLine(users.FirstOrDefault().FirstName);

                var cards = context.Cards.Where(w => w.Id == card.Id).FirstOrDefault();

                Console.WriteLine(cards.CardNumber);
            }
        }
    }
}
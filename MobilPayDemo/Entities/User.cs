using System.ComponentModel.DataAnnotations;

namespace MobilPayDemo.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(55), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(55), MinLength(2)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}

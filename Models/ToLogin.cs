using System.ComponentModel.DataAnnotations;

namespace MVCFoodDelivery.Models
{
    public class ToLogin
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

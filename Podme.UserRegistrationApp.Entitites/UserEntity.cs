using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Podme.UserRegistrationApp.Api.Entitites
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public int GenderId { get; set; }

    }
}
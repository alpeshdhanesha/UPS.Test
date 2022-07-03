using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USP.Model
{
    [Table("userInfo")]
    public class UserDto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }


        [Column("Address")]
        public string Address { get; set; }

        [Column("Contact")]
        public string Contact { get; set; }
    }
}

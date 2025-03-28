using System.ComponentModel.DataAnnotations;

namespace SMS_APDP.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

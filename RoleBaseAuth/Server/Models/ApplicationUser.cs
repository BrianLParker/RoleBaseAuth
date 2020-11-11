namespace RoleBaseAuth.Server.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Planet { get; set; }
    }
}

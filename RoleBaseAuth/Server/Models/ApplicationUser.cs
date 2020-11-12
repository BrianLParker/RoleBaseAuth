namespace RoleBaseAuth.Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Planet { get; set; }
    }
}

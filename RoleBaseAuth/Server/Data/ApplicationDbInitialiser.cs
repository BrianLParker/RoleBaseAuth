namespace RoleBaseAuth.Server.Data
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using RoleBaseAuth.Server.Models;

    public static class ApplicationDbInitialiser
    {

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            AddRoleIfNotExists(roleManager, "Administrator");
            AddRoleIfNotExists(roleManager, "Moderator");
            AddRoleIfNotExists(roleManager, "TenantAdmin");
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            (string name, string planet, string password, string role)[] demoUsers = new[]
            {
                (name: "sally@sally.com", planet: "Venus", password: "Passw0rd!", role: "Administrator"),
                (name: "bob@bob.com", planet: "Mars", password: "Passw0rd!", role: "Moderator"),
                (name: "abi@abi.com", planet: "Kepler-1649c", password: "Passw0rd!", role: "TenantAdmin,Moderator"),
                (name: "fred@fred.com", planet: "Earth", password: "Passw0rd!", role: "")
            };

            foreach ((string name, string planet, string password, string role) user in demoUsers)
            {
                AddUserIfNotExists(userManager, user);
            }

        }

        private static void AddUserIfNotExists(UserManager<ApplicationUser> userManager, (string name, string planet, string password, string role) demoUser)
        {
            ApplicationUser user = userManager.FindByNameAsync(demoUser.name).Result;
            if (user == default)
            {
                var newAppUser = new ApplicationUser
                {
                    UserName = demoUser.name,
                    Planet = demoUser.planet,
                    Email = demoUser.name,
                    EmailConfirmed = true
                };
                _ = userManager.CreateAsync(newAppUser, demoUser.password).Result;
                if (!string.IsNullOrWhiteSpace(demoUser.role))
                {
                    var roles = demoUser.role.Split(',').Select(a => a.Trim()).ToArray();
                    Console.WriteLine($"{roles.Length}");
                    foreach (var role in roles)
                    {
                        _ = userManager.AddToRoleAsync(newAppUser, role).Result;

                    }
                }

            }
        }

        private static void AddRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.FindByNameAsync(roleName).Result == default)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName }).Wait();
            }
        }
    }
}

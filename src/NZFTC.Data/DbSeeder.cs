using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NZFTC.Data.Entities;

namespace NZFTC.Data
{
    public static class DbSeeder
    {
        public static async Task SeedIdentityAsync(IServiceProvider services)
        {
            // Resolve managers from DI
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            var userManager = services.GetRequiredService<UserManager<User>>();

            // Roles to ensure exist
            var roles = new[] { "Admin", "User", "Dev" };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new Role
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpperInvariant()
                    };

                    // Ensure primary key is populated if not provided by the model/DB
                    if (string.IsNullOrWhiteSpace(role.Id))
                    {
                        role.Id = Guid.NewGuid().ToString();
                    }

                    var roleResult = await roleManager.CreateAsync(role);
                    if (!roleResult.Succeeded)
                    {
                        var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                        throw new InvalidOperationException($"Failed to create role '{roleName}': {errors}");
                    }
                }
            }

            // Create a seeded admin user if one does not exist
            var adminEmail = "admin@local.test";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                // Ensure primary key is populated if not provided by the model/DB
                if (string.IsNullOrWhiteSpace(adminUser.Id))
                {
                    adminUser.Id = Guid.NewGuid().ToString();
                }

                var createUserResult = await userManager.CreateAsync(adminUser, "Passw0rd!");
                if (!createUserResult.Succeeded)
                {
                    var errors = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                    throw new InvalidOperationException($"Failed to create admin user: {errors}");
                }
            }

            // Ensure admin user is in Admin role
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                if (!addToRoleResult.Succeeded)
                {
                    var errors = string.Join(", ", addToRoleResult.Errors.Select(e => e.Description));
                    throw new InvalidOperationException($"Failed to add admin user to role 'Admin': {errors}");
                }
            }
        }
    }
}
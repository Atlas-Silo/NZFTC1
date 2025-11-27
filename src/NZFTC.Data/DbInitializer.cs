// DbInitializer.cs - NZFTC.Data

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NZFTC.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await context.Database.MigrateAsync();

        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        if (!await roleManager.RoleExistsAsync("User"))
            await roleManager.CreateAsync(new IdentityRole("User"));

        var adminEmail = "admin@example.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            var user = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, "Admin123!");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }

        if (!context.Holidays.Any())
        {
            context.Holidays.Add(new Holiday { Date = new DateTime(DateTime.Today.Year, 12, 25), Name = "Christmas Day" });
            await context.SaveChangesAsync();
        }
    }
}

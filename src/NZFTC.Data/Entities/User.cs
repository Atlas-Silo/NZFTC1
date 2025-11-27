using Microsoft.AspNetCore.Identity;

namespace NZFTC.Data.Entities
{
    // Explicitly inherit from IdentityUser<string>
    public class User : IdentityUser<string>
    {
        // Add custom fields here if needed
    }

    // Explicitly inherit from IdentityRole<string>
    public class Role : IdentityRole<string>
    {
        // Add custom fields here if needed
    }
}
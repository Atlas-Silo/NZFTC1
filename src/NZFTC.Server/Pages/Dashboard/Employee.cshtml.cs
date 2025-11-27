using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NZFTC.Server.Pages.Dashboard
{
    public class UserDashModel : PageModel
    {
        public ProfileInfo Profile { get; set; } = new();

        [BindProperty]
        public ContactInfo Contact { get; set; } = new();

        [TempData]
        public string? Flash { get; set; }

        public LeaveInfo Leave { get; set; } = new();

        public void OnGet()
        {
            // Stub data — replace with service calls
            Profile = new ProfileInfo
            {
                FullName = "John Smith",
                Position = "Senior Developer",
                Id = "EMP001",
                Email = "john.smith@nzftc.co.nz",
                Department = "Engineering",
                StartDate = new DateTime(2020, 3, 15),
                Role = "Employee"
            };

            Contact = new ContactInfo
            {
                Phone = "+64 21 123 4567",
                Address1 = "1 Sample Street",
                City = "Auckland",
                Postcode = "1010"
            };

            Leave = new LeaveInfo
            {
                Annual = 15.0,
                Sick = 5.0
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            // TODO: persist Contact changes via service
            Flash = "Contact info saved.";
            return RedirectToPage();
        }

        public class ProfileInfo
        {
            public string FullName { get; set; } = string.Empty;
            public string Position { get; set; } = string.Empty;
            public string Id { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
            public DateTime? StartDate { get; set; }
            public string Role { get; set; } = string.Empty;
        }

        public class ContactInfo
        {
            public string Phone { get; set; } = string.Empty;
            public string Address1 { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string Postcode { get; set; } = string.Empty;
        }

        public class LeaveInfo
        {
            public double? Annual { get; set; }
            public double? Sick { get; set; }
        }
    }
}
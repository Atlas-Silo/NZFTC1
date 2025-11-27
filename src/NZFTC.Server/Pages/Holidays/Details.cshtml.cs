using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Server.Pages.Holidays
{
    public class HolidayDetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public HolidayDetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public HolidayDto Holiday { get; set; } = new();

        public string HolidayName { get; set; } = "";
        public DateTime HolidayDate { get; set; }
        public string Region { get; set; } = "";

        // returns null so can create new holiday
        // or the existing holiday ID for edit mode
        public int? Id => Holiday != null && Holiday.Id != 0
        ? Holiday.Id
        : (int?)null;


        public bool IsSuccess { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Holiday = new HolidayDto();
                return Page();
            }

            try
            {
                Holiday = await _httpClient.GetFromJsonAsync<HolidayDto>($"http://localhost:5000/api/holiday/{id}");

                if (Holiday == null)
                {
                    return NotFound();
                }

                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                if (Holiday.Id == 0)
                {
                    // CREATE
                    await _httpClient.PostAsJsonAsync("http://localhost:5000/api/holiday", Holiday);
                }
                else
                {
                    // UPDATE
                    await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/holiday/{Holiday.Id}", Holiday);
                }

                return RedirectToPage("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the holiday.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (Holiday.Id == 0)
            {
                return NotFound();
            }

            try
            {
                await _httpClient.DeleteAsync($"http://localhost:5000/api/holiday/{Holiday.Id}");
                return RedirectToPage("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the holiday.");
                return Page();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Pages.Holidays
{
    public class HolidaysIndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public HolidaysIndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<HolidayDto> Holidays { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                var holidays = await _httpClient.GetFromJsonAsync<List<HolidayDto>>("http://localhost:5000/api/holiday");
                Holidays = holidays ?? new List<HolidayDto>();
            }
            catch
            {
                Holidays = new List<HolidayDto>();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NZFTC.Shared.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NZFTC.Pages.Dashboard
{
    public class Dashboard : PageModel
    {
        private readonly HttpClient _httpClient;

        public Dashboard(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    // Main dashboard for admin users showing key metrics
    public int TotalEmployees { get; set; }
    public int ActiveEmployees { get; set; }
    public int UpcomingHolidays30d { get; set; }

    public void OnGet()
    {

        // Employee and holiday api calls
        TotalEmployees = 150;
        ActiveEmployees = 142;
        UpcomingHolidays30d = 3;
    }

    }
}

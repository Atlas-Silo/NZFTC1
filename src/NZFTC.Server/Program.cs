using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using NZFTC.Data;
using NZFTC.Data.Entities;
using NZFTC.Shared.Interfaces;
using NZFTC.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddRazorPages();

// Register HttpClient for DI (named client for NZFTC API)
builder.Services.AddHttpClient("NZFTC", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000"); // adjust if your API runs elsewhere
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
var devOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                 ?? new[] { "http://localhost:3000", "http://127.0.0.1:3000", "http://localhost:5173", "http://localhost:4200" };
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalFrontend", p => p
        .WithOrigins(devOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

// Register AppDbContext (SQLite fallback for local dev)
var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=nzftc.db";
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

// Register Identity with custom User/Role
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Application services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IGrievanceService, GrievanceService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();
builder.Services.AddScoped<IRoleService, RoleService>();

var app = builder.Build();

// Optional: listen on both ports for convenience (3000 and 5000)
app.Urls.Clear();
app.Urls.Add("http://0.0.0.0:3000");
app.Urls.Add("http://0.0.0.0:5000");

// Apply migrations and seed identity
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetService<AppDbContext>();
        if (db != null)
        {
            db.Database.Migrate();
            DbSeeder.SeedIdentityAsync(services).GetAwaiter().GetResult();
        }
        else
        {
            var logger = services.GetRequiredService<Microsoft.Extensions.Logging.ILogger<Program>>();
            logger.LogWarning("AppDbContext not registered; skipping migrations and seeding.");
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<Microsoft.Extensions.Logging.ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        throw;
    }
}

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = "swagger";
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "NZFTC API V1");
});

// CORS, Auth
app.UseCors("LocalFrontend");
app.UseAuthentication();
app.UseAuthorization();

// Debug middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"REQ -> {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");
    await next();
});

// Map endpoints
app.MapControllers();
app.MapRazorPages();

// Removed Blazor-specific endpoints (MapBlazorHub, MapFallbackToPage("/_Host"))

app.Run();
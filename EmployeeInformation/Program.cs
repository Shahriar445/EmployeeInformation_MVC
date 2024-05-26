using EmployeeInformation.Interface;
using EmployeeInformation.IRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register IEmployee with its implementation EmployeeRepository
builder.Services.AddScoped<IEmployee, EmployeeRepository>();



 //Configure HTTPS redirection & HSTS

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(365);
}
);
builder.Services.AddHttpsRedirection(options =>

{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    options.HttpsPort = 7220;
});


//configure authentication with cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensures cookies are only sent over HTTPS
        options.LoginPath = "/Account/Login"; // Redirect to login page
        options.LogoutPath = "/Account/Logout"; // Redirect to logout page
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromSeconds(30); // Set session timeout

        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                context.Response.Redirect(context.RedirectUri);
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthentication();















var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using Google.Apis.Auth.AspNetCore3;
using Mentor.Me.Domain.Hubs;
using Mentor.Me.Domain.Models;
using Mentor.Me.Web.ServiceExtensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.Configure<GoogleOAuthConfig>(builder.Configuration.GetSection("GoogleOAuthConfig"));

var secOpts = builder.Configuration
    .GetSection("GoogleOAuthConfig")
    .Get<GoogleOAuthConfig>();

builder.Services.AddAuthentication(o =>
    {
        o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
        o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/api/v1/users/authenticate";
    })
    .AddGoogleOpenIdConnect(options =>
    {
        options.ClientId = secOpts.ClientId;
        options.ClientSecret = secOpts.ClientSecret;
    })
    .AddGoogle(options =>
    {
        options.ClientId = secOpts.ClientId;
        options.ClientSecret = secOpts.ClientSecret;
    });

builder.Services.AddCors();

builder.Services.ConfigureDbContext();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("https://localhost:44408", "https://localhost:7024", "http://localhost:5024")
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SignalRHub>("api/v1/chats/messages-hub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html"); ;

app.Run();

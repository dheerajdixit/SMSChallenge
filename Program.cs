using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SMS.Code.Challenge.Common.MongoDB;
using SMS.Code.Challenge.Common.Settings;
using SMS.Code.Challenge.Service.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceSettings serviceSettings;
serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie().AddOpenIdConnect("Auth0", option =>
 {
     option.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
     option.ClientId = builder.Configuration["Auth0:ClientId"];
     option.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
     option.ResponseType = OpenIdConnectResponseType.Code;
     option.Scope.Clear();
     option.Scope.Add("openid");
     option.CallbackPath = new PathString("/callback");
     option.ClaimsIssuer = "Auth0";
     option.Events = new OpenIdConnectEvents
     {
         OnRedirectToIdentityProviderForSignOut = (context) =>
         {
             var logoutUri = $"https://{builder.Configuration["Auth0:Domain"]}/v2/logout?client_id={builder.Configuration["Auth0:ClientId"]}";
             var postLogoutUri = context.Properties.RedirectUri;
             if (!string.IsNullOrEmpty(postLogoutUri))
             {
                 if (postLogoutUri.StartsWith("/"))
                 {
                     var request = context.Request;
                     postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                 }
                 logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
             }
             context.Response.Redirect(logoutUri);
             context.HandleResponse();
             return Task.CompletedTask;
         }
     };

 });
builder.Services.AddMongo().AddMongoRepository<CityVisit>("CityVisits", @"Seed/data.json");
// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

using SMS.Code.Challenge.Common.MongoDB;
using SMS.Code.Challenge.Common.Settings;
using SMS.Code.Challenge.Service.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceSettings serviceSettings;
serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();


builder.Services.AddMongo().AddMongoRepository<CityVisit>("CityVisits", @"C:\Users\Dheeraj.Dixit\Documents\BackendDotnet\data.json");
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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

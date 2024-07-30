using Blazored.LocalStorage;
using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.Provider;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookingSystemDlsContext>();
builder.Services.AddScoped<BookingCodeProvider>();
builder.Services.AddScoped<ResourceProvider>();
builder.Services.AddScoped<ResourceDetailProvider>();
builder.Services.AddScoped<RoomProvider>();
builder.Services.AddScoped<LocationProvider>();
builder.Services.AddScoped<MenuProvider>();
builder.Services.AddScoped<GlobalSetupProvider>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

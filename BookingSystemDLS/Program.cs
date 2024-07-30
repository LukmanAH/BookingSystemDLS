using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.Provider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<BookingCodeProvider>();
builder.Services.AddScoped<MenuProvider>();
builder.Services.AddScoped<RoomProvider>();
builder.Services.AddScoped<LocationProvider>();
builder.Services.AddScoped<ResourceProvider>();
builder.Services.AddScoped<ResourceDetailProvider>();
builder.Services.AddScoped<GlobalSetupProvider>();
builder.Services.AddScoped<EmailProvider>();
builder.Services.AddScoped<BookingSystemDlsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

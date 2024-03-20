using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Eyeglasses2024DBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("EyeGlass");
    options.UseSqlServer(connectionString);
});


// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("EyeGlass");

builder.Services.AddTransient<UnitOfWork>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

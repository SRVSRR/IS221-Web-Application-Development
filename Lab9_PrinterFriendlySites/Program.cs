using Microsoft.EntityFrameworkCore;
using Lab7_StudentRegistration.Data;
using Lab7_StudentRegistration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<XmlDataService>();

// Configure SQLite
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("StudentDbConnection")));

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
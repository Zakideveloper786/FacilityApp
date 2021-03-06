
using FacilityApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextFactory<FacilityAppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".facilityapp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
var alloworigin = "AllowOrigin";
builder.Services.AddCors(c =>
{
    c.AddPolicy(name: alloworigin, options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(alloworigin);
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

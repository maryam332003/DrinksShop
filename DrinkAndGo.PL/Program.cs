using DrinkAndGo.BLL.Interfaces;
using DrinkAndGo.BLL.Repositories;
using DrinkAndGo.DAL.Data;
using DrinkAndGo.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped(typeof(IDrinkRepository),typeof(DrinkRepository));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp =>
{
    var context = sp.GetRequiredService<AppDbContext>();
    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
    return ShoppingCart.GetCart(context, httpContextAccessor);
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});



builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
DbInitializer.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

    );
app.MapControllerRoute(

    name: "categoryFilter",
    pattern: "{Controller=Drink}/{action=List}/{category?}"

    );


app.Run();

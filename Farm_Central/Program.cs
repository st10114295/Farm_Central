 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Farm_Central.Data;
using Farm_Central.Areas.Identity.Data;
using Farm_Central.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDBContextConnection' not found.");

builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//DI
builder.Services.AddDbContext<FarmerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbContextConnection"))
);
builder.Services.AddDbContext<ProductDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbContextConnection"))
);

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

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
app.MapRazorPages();

app.Run();

using Entities;
using Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using Services;
using Services.ProjectServices;

var builder = WebApplication.CreateBuilder(args);
/*dotnet ef migrations add MyMigration --startup-project ..\PMS_Software
dotnet ef database update --project . --startup-project ..\PMS_Software*/
// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IUsersService,UserService>();
builder.Services.AddScoped<IIssueService,IssueService>();
builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddDbContext<PMS_DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("Entities"));
});
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PMSDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<PMS_DBContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric= false;
    options.Password.RequireLowercase= false;
    options.Password.RequireUppercase=false;
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
app.UseAuthentication();
app.UseCors();
app.UseAuthorization();
/*app.UseStatusCodePagesWithRedirects("/NotFound");
app.MapControllerRoute(
    name: "NotFound",
    pattern: "/NotFound",
    defaults: new { controller = "Error", action = "NotFound" }
);*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

using MyQuizlet.Application.Extensions;
using MyQuizlet.Infrastructure.Extensions;
using MyQuizlet.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Identity/SignIn";
	options.AccessDeniedPath = "/Identity/AccessDenied";
	options.ExpireTimeSpan = TimeSpan.FromDays(1);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Error");
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseStaticFiles();

app.Run();

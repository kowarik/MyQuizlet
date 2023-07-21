using MyQuizlet.Application.Extensions;
using MyQuizlet.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/SignIn";
    options.AccessDeniedPath = "/Identity/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

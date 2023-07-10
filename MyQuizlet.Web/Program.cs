using MyQuizlet.Application.Extensions;
using MyQuizlet.Infrastructure.Extensions;
using MyQuizlet.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Error");
}

//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();

app.UseStaticFiles();

app.Run();

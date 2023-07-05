using MyQuizlet.Application.Extensions;
using MyQuizlet.Infrastructure.Extensions;
using MyQuizlet.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();

app.UseStaticFiles();

app.Run();

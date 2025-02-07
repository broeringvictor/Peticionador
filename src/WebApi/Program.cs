using Infrastructure.Data.Identity.UseCases;
using WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.AddConfiguration();




var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultOpenApi();
app.Run();


app.Run();
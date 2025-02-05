using WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.AddConfiguration();


builder.Services.AddOpenApi();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultOpenApi();


app.Run();
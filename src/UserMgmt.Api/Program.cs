using UserMgmt.Sdk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddUserMgmtSdk("http://localhost:3000");

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI at application root
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserMgmt.Api v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Urls.Add("http://localhost:5000");

app.Run();

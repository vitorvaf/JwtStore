using JwtStore.Api.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

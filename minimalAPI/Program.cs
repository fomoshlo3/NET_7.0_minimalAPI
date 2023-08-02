//NOTE: https://youtu.be/RRrsFE6OXAQ

using minimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();


//NOTE: https://youtu.be/RRrsFE6OXAQ

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();


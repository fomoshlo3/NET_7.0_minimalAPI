//NOTE: https://youtu.be/RRrsFE6OXAQ

using Application.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SocialDbContext>(opt=> opt.UseSqlServer("name=ConnectionStrings:Default"));
builder.Services.AddScoped<IPostRepository, PostRepository>();


var app = builder.Build();

app.UseHttpsRedirection();
 
app.Run();

 
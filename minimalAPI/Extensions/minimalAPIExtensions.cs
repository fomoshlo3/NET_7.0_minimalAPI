using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using minimalAPI.Abstractions;

namespace minimalAPI.Extensions
{
    public static class minimalAPIExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            //Change ConnectionStrings in appsettiongs.json
            builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer("name=ConnectionStrings:AtWork"));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(typeof(CreatePost));
        }

        /// <summary>
        /// Scans Assembly for Types that are assignable or implement IEndpointInterfac if they're not Interfaces or Abstract
        /// </summary>
        /// <param name="app"></param>
        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.RegisterEndpoints(app);
            }
        }
    }
}

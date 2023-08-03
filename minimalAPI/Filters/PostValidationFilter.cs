using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace minimalAPI.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(1); //This is Index 1 because of PostEndpointDefinitions, 0 Index arg would be IMediator mediator
            if (post.Content.IsNullOrEmpty())
            {
                return await Task.FromResult(Results.BadRequest("Post not valid"));
            }
            return await next(context);
        }
    }
}

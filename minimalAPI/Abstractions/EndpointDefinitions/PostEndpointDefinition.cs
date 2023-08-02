using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace minimalAPI.Abstractions.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("api/posts"); //Map groupd sets root route

            posts.MapGet("/{id}", GetPostById) //<= This is now a delegate, so IDE auto overloads IMediator and an int Id
            //Adding Metadata
            .WithName("GetPostById");
            posts.MapPost("/",CreatePost);
            posts.MapGet("/",GetAllPosts);
            posts.MapPut("/{id}",UpdatePost);
            posts.MapDelete("/{id}",DeletePost);
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var getPost = new GetPostById { PostId = id };
            var post = await mediator.Send(getPost);
            return TypedResults.Ok(post);
        }

        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var createPost = new CreatePost { PostContent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            var getCommand = new GetAllPosts();
            var posts = await mediator.Send(getCommand);
            return TypedResults.Ok(posts);
        }
        private async Task<IResult> UpdatePost(IMediator mediator, Post post, int id)
        {
            var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return TypedResults.Ok(updatedPost);
        }
        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            var deletePost = new DeletePost { PostId = id };
            await mediator.Send(deletePost);
            return TypedResults.NoContent();
        }
    }
}

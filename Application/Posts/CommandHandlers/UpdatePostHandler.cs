using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository _postsRepo;

        public UpdatePostHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }
        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var post = await _postsRepo.UpdatePost(request.PostContent, request.PostId);
            return post;
        }
    }
}

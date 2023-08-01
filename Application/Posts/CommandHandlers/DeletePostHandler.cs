using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;


namespace Application.Posts.CommandHandlers
{
    //TODO: research what may be the problem with Unit.Value
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postsRepo;
        public DeletePostHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postsRepo.DeletePost(request.PostId);
            return Unit.Value;
        }

        //Task IRequestHandler<DeletePost>.Handle(DeletePost request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

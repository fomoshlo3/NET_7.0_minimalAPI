using Domain.Models;
using MediatR;

namespace Application.Posts.Commands
{
    public class DeletePost : IRequest
    {
        public int PostId { get; set; }
    }
}

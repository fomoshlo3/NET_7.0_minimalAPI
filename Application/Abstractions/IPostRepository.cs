using Domain.Models;
using MediatR;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        public Task<ICollection<Post>> GetAllPosts();
        public Task<Post> GetPostById(int postId);
        public Task<Post> CreatePost(Post toCreate);
        public Task<Post> UpdatePost(string updateContent, int postId);
        public Task DeletePost (int postId);
    }
}

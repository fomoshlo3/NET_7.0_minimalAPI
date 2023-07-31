using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        public Task<ICollection<Post>> GetAllPosts();
        public Task<Post> GetPost(int postId);
        public Task<Post> CreatePost(Post toCreate);
        public Task<Post> UpdatePost(string updateContent, int postId);
        public Task DeletePost (int postId);
    }
}

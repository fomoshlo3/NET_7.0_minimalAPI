using Application.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _ctx;

        public PostRepository(SocialDbContext context)
        {
              _ctx = context;
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.DateLastModified = DateTime.Now;
            _ctx.Posts.Add(toCreate);
            await _ctx.SaveChangesAsync();
            return toCreate;
        }

        public Task DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPost(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(string updateContent, int postId)
        {
            throw new NotImplementedException();
        }
    }
}

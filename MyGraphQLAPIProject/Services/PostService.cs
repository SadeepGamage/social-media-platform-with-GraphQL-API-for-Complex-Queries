using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGraphQLAPIProject.Data;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.Services
{
    public class PostService:IPostService
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context= context;
        }

        public async Task<PostModel> CreatePostAsync(PostModel post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<PostModel>> GetAllPostAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<PostModel?> GetPostByIdAsync(int postId)
        {
            return await _context.Posts.Include(p=>p.User).Include(p=>p.Comments).FirstOrDefaultAsync(p => p.PostId == postId);
        }

        public async Task<List<PostModel>> GetPostByUserAsync(int userId)
        {
            return await _context.Posts.Where(p =>p.UserId == userId).ToListAsync();
        }
    }
}
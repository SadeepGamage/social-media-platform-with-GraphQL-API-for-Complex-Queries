using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGraphQLAPIProject.Data;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.Services
{
    public class CommentService:ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context= context;
        }

        public async Task<CommentModel> CreateCommentAsync(CommentModel comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<CommentModel>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<List<CommentModel>> GetCommetsByPostId(int postId)
        {
            return await _context.Comments.Where(p =>p.PostId==postId).Include(c=>c.User).ToListAsync();
        }
    }
}
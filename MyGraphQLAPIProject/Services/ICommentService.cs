using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.Services
{
    public interface ICommentService
    {
        Task<List<CommentModel>> GetAllCommentsAsync();
        Task<List<CommentModel>> GetCommetsByPostId (int postId);
        Task<CommentModel>CreateCommentAsync(CommentModel comment);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.Services
{
    public interface IPostService
    {
        Task<List<PostModel>>GetAllPostAsync();
        Task<PostModel?>GetPostByIdAsync(int postId);
        Task<PostModel>CreatePostAsync(PostModel post);
        Task<List<PostModel>>GetPostByUserAsync(int userId);
    }
}
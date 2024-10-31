using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.Services
{
    public interface IUserService
    {
        Task<List<UserModel>>GetAllUsersAsync();
        Task<UserModel?>GetUserByIdAsync(int userId);
        Task<UserModel>CreateUserAsync(UserModel user);
    }
}
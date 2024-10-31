using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<UserModel> Users { get;set;}
        public DbSet<PostModel>Posts { get;set ; }
        public DbSet<CommentModel>Comments { get;set;}
    }
}
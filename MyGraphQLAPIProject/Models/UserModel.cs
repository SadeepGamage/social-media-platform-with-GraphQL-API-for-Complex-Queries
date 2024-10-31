using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQLAPIProject.Models
{
    public class UserModel
    {
        [Key]
        public int UserId {get;set;}
        public string Username { get;set;}
        public string Email { get;set;}
        public List<PostModel> Posts { get;set;}
    }
}
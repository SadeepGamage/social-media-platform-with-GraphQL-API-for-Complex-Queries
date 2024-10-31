using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQLAPIProject.Models
{
    public class PostModel
    {
        [Key]
        public int PostId { get;set;}
        public string Content { get;set; }
        public DateTime CreatedDate { get;set; }
        [ForeignKey("User")]
        public int UserId { get;set;}
        public UserModel User { get;set;}
        public List<CommentModel>Comments { get;set; }
    }
}
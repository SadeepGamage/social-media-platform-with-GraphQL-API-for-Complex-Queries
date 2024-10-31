using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQLAPIProject.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get;set; }
        public string Content { get;set; }
        public DateTime CreatedDate { get;set; }
        [ForeignKey("User")]
        public int UserId { get;set; }
        public UserModel User { get;set; }
        [ForeignKey("Post")]
        public int PostId {set;get; }
        public PostModel Post { get;set; }
    }
}
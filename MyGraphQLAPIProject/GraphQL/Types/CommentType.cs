using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.GraphQL.Types
{
    public class CommentType:ObjectGraphType<CommentModel>
    {
        public CommentType()
        {
            Field(x => x.CommentId).Description("The unique identifier of the comment.");
            Field(x => x.Content).Description("The content of the comment.");
            Field(x => x.CreatedDate).Description("The date the comment was created.");
            Field<UserType>("user", "The author of the comment");
            Field<PostType>("post", "The post the comment belongs to");
            
        }
    }
}
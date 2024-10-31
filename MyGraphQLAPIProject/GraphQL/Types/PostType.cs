using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.GraphQL.Types
{
    public class PostType:ObjectGraphType<PostModel>
    {
        public PostType()
        {
            Field(x => x.PostId).Description("The unique identifier of the post.");
            Field(x => x.Content).Description("The content of the post.");
            Field(x => x.CreatedDate).Description("The date the post was created.");
            Field<UserType>("user", "The author of the post");
            Field<ListGraphType<CommentType>>("comments", "Comments on the post");
        }
    }
}
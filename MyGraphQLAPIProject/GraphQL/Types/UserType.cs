using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyGraphQLAPIProject.Models;

namespace MyGraphQLAPIProject.GraphQL.Types
{
    public class UserType:ObjectGraphType<UserModel>
    {
        public UserType()
        {
            Field(x=>x.UserId).Description("The Unique Identifier of the User");
            Field(x=>x.Username).Description("The username of the user");
            Field(x=>x.Email).Description("The Email address of the user");
            Field<ListGraphType<PostType>>("posts" , "Posts Created By the User");
        }
    }
}
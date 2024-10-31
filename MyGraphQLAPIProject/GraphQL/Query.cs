using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using MyGraphQLAPIProject.GraphQL.Types;
using MyGraphQLAPIProject.Services;

namespace MyGraphQLAPIProject.GraphQL
{
    public class Query:ObjectGraphType
    {
        public Query(IUserService userService , IPostService postService , ICommentService commentService)
        {
            Field<ListGraphType<UserType>>(
                "users",
                resolve:context=>userService.GetAllUsersAsync()
            );
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"}),
                resolve: context=>userService.GetUserByIdAsync(context.GetArgument<int>("id"))
            );
            Field<ListGraphType<CommentType>>(
                "posts",
                resolve:context =>postService.GetAllPostAsync()
            );
            Field<ListGraphType<CommentType>>(
                "comments",
                resolve:context=>commentService.GetAllCommentsAsync()
            );
        }
    }
}
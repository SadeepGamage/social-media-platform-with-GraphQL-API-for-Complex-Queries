using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using MyGraphQLAPIProject.GraphQL.Types;
using MyGraphQLAPIProject.Models;
using MyGraphQLAPIProject.Services;

namespace MyGraphQLAPIProject.GraphQL
{
    public class Mutation:ObjectGraphType
    {
        public Mutation(IUserService userService , IPostService postService  , ICommentService commentService)
        {
            Field<UserType>(
                "createUser",
                arguments:new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "username"},
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "email"}
                ),
                resolve:context=>
                {
                    var username = context.GetArgument<string>("username");
                    var email = context.GetArgument<string>("email");
                    return userService.CreateUserAsync(new UserModel {Username =username , Email = email});
                }
            );

            Field<PostType>(
                "createPost",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "content" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "userId" }
                ),
                resolve: context =>
                {
                    var content = context.GetArgument<string>("content");
                    var userId = context.GetArgument<int>("userId");
                    return postService.CreatePostAsync(new PostModel { Content = content, UserId = userId });
                }
            );

            Field<CommentType>(
                "addComment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "content" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "postId" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "userId" }
                ),
                resolve: context =>
                {
                    var content = context.GetArgument<string>("content");
                    var postId = context.GetArgument<int>("postId");
                    var userId = context.GetArgument<int>("userId");
                    return commentService.CreateCommentAsync(new CommentModel { Content = content, PostId = postId, UserId = userId });
                }
            );
        }
    }
}
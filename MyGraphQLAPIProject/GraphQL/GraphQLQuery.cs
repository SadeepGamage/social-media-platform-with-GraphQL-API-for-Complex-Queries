using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MyGraphQLAPIProject.GraphQL
{
    public class GraphQLQuery
    {
        public string? OperationName { get;set;}
        public string Query  {get;set; } = string.Empty;
        public JObject Variables { get;set; } = new JObject();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using MyGraphQLAPIProject.GraphQL;

namespace MyGraphQLAPIProject.Controllers
{
    [ApiController]
    [Route("graph")]
    public class GraphQLController:ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLController(ISchema schema , IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }
        [HttpPost]
        public async Task<IActionResult>Post([FromBody]  GraphQLQuery query)
        {
            if(query == null || string.IsNullOrWhiteSpace(query.Query))
            {
                return BadRequest("Invalid Query");
            }
            var executionOptions =  new ExecutionOptions
            {
                Schema = (global::GraphQL.Types.ISchema)_schema,
                Query = query.Query,
                // Variables= query.Variables.ToInputs(),
                OperationName = query.OperationName
            };
            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
            if(result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);
        }
    }
}
using Cosmos_Study.Application.Features.Study.Commands;
using Cosmos_Study.Application.Features.Study.Queries;
using Cosmos_Study.Application.Features.Study.Queries.GetAllStudy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Serilog.Core;
using System;
using System.Threading.Tasks;

namespace Cosmos_Study.WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class StudyController : BaseApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(CreateStudyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetStudyByIdQuery { Id = id }));
        }

        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllStudyParameter parameter)
        {
            return Ok(await Mediator.Send(new GetAllStudyWithPagination { PageNumber = parameter.PageNumber, PageSize = parameter.PageSize, EmbeddedId = parameter.EmbeddedId }));
        }

        // DELETE api/<controller>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new DeleteStudyByIdCommand { Id = id }));
        }

        // PUT api/<controller>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateStudyCommand command)
        {
            if (id != command.StudyUniqueId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}

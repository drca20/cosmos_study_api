using Cosmos_Study.Application.Features.Study.Commands;
using Cosmos_Study.Application.Features.Study.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cosmos_Study.WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class StudyContactController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateStudyContactsCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    return Ok(await Mediator.Send(new GetStudyByIdQuery { Id = id }));
        //}

        // DELETE api/<controller>/5
        //[Authorize]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    return Ok(await Mediator.Send(new DeleteStudyByIdCommand { Id = id }));
        //}

        // PUT api/<controller>/5
        //[Authorize]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(string id, UpdateStudyCommand command)
        //{
        //    if (id != command.StudyUniqueId)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}
    }

}


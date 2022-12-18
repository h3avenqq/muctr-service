using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Professors.Queries.GetProfessorList;
using System;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProfessorController : BaseController
    {
        private readonly IMapper _mapper;

        public ProfessorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProfessorListVm>> GetAll(Guid facultyId)
        {
            var professorQuery = new GetProfessorListQuery
            {
                FacultuId = facultyId
            };

            var vm = Mediator.Send(professorQuery);

            //return Ok(vm);
            return BadRequest();
        }
    }
}

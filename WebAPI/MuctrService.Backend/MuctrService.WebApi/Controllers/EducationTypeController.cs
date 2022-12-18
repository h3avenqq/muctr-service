using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.EducationType.Query.GetEducationTypeList;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EducationTypeController : BaseController
    {
        private readonly IMapper _mapper;

        public EducationTypeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EducationTypeListVm>> GetAll()
        {
            var educationTypeQuery = new GetEducationTypeListQuery();

            var vm = await Mediator.Send(educationTypeQuery);

            return Ok(vm);
        }
    }
}

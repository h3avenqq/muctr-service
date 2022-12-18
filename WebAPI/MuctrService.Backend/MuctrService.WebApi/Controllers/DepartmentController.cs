using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Departments.Queries.GetDepartmentList;
using System;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DepartmentListVm>> GetAll(Guid facultyId)
        {
            var departmentQuery = new GetDepartmentListQuery
            {
                FacultyId = facultyId
            };

            var vm = await Mediator.Send(departmentQuery);

            return Ok(vm);
        }
    }
}

using Demo.Api.Data;
using Demo.Api.Models;
using Demo.Api.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private EmployeeContext context;
        public DepartmentController(EmployeeContext context)
        {
            this.context = context;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuilderForm.API.Helpers;
using BuilderForm.API.Models.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BuilderForm.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/forms")]
    public class FormsController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]CreateFormModel form)
        {
            return Ok();
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(Guid? id)
        {
            return Ok();
        }
    }
}

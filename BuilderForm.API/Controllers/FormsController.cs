using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuilderForm.API.Helpers;
using BuilderForm.API.Models.Forms;
using BuilderForm.Data.Entities;
using BuilderForm.DataService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BuilderForm.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/forms")]
    public class FormsController : ApiController
    {
        private readonly IFormService formService;

        public FormsController(IFormService formService)
        {
            this.formService = formService;
        }


        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]CreateFormModel model)
        {
            var form = new Form()
            {
                FormSchema = model.FormSchema,
                Name = model.FormName,
                Url = model.FormName.GetFriendlyUrl(),
                Key = Guid.NewGuid()
            };
            if (formService.Add(form))
                return Ok(form);
            return BadRequest();
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(Guid? id)
        {
            if (!id.HasValue) return BadRequest();
            var form = formService.GetFormById(id.Value);
            form.Key = Guid.Empty;
            return Ok(form);
        }
    }
}

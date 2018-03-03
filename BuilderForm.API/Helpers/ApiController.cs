using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuilderForm.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuilderForm.API.Helpers
{
    public class ApiController : Controller
    {

        #region Ok

        [NonAction]
        public override OkResult Ok()
        {
            IActionResult result = StatusCode(200, new APIResponse(true));
            
            return base.Ok();
        }

        [NonAction]
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(new APIResponse(value, true, null));
        }

        [NonAction]
        public virtual OkObjectResult Ok(object value, params string[] messages)
        {
            return base.Ok(new APIResponse(value, true, messages));
        }

        #endregion

        #region NotFound

        [NonAction]
        public override NotFoundResult NotFound()
        {
            IActionResult result = StatusCode(404, new APIResponse(false, "Ulaştığınız kaynak bulunamadı"));
            return result as NotFoundResult;
        }

        [NonAction]
        public override NotFoundObjectResult NotFound(object value)
        {
            return base.NotFound(new APIResponse(null, false, $"Ulaştığınız {value.ToString()} kaynak bulunamadı"));
        }

        [NonAction]
        public virtual NotFoundObjectResult NotFound(object value, params string[] messages)
        {
            var listMessages = messages.ToList();
            listMessages.Add(value.ToString());
            return base.NotFound(new APIResponse(null, false, listMessages.ToArray()));
        }

        #endregion

        #region BadRequest

        [NonAction]
        public override BadRequestResult BadRequest()
        {
            IActionResult result = StatusCode(400, new APIResponse(false, "Ulaştığınız kaynak bulunamadı"));
            return result as BadRequestResult;
        }

        [NonAction]
        public override BadRequestObjectResult BadRequest(object value)
        {
            return base.BadRequest(new APIResponse(value, false, $"Ulaştığınız {value.ToString()} kaynak bulunamadı"));
        }

        [NonAction]
        public virtual BadRequestObjectResult BadRequest(object value, params string[] messages)
        {
            return base.BadRequest(new APIResponse(value, false, messages));
        }

        #endregion

        #region UnAuthorized

        [NonAction]
        public override UnauthorizedResult Unauthorized()
        {
            IActionResult result = StatusCode(401, new APIResponse(false, "Giriş yapmak zorundasınız"));
            return result as UnauthorizedResult;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FormBuilder.Web.Controllers
{
    public class FormsController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        public PartialViewResult GetAnswers()
        {
            return PartialView();
        }
    }
}
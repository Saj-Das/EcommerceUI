using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Renova.Controllers
{
    [Route("api/[controller]")]
    public class homeController : Controller
    {
      [HttpGet]
        public ActionResult upload() {
            return Json(new {foo="bar", baz="Blech",list="[asa,asa]"});
        } 

      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Renova.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace Renova.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FormController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        MongoClient _client;
        IMongoDatabase _db;


        public FormController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("Renova");
        }

        [HttpPost]
        public ActionResult ProductAdd([FromBody]Product product)
        {
            try
            {   var collection = _db.GetCollection<Product>("Product");
                collection.InsertOne(product);
                return Json(new { result ="done"  });
            }
            catch (System.Exception ex)
            {
                return Json(new { result =ex.Message }); ;

            }
        }
        [HttpPost]
        public ActionResult UserAdd([FromBody]User user)
        {
            try
            {
                var collection = _db.GetCollection<User>("User");
                collection.InsertOne(user);
                return Json(new { result = "done" });
            }
            catch (System.Exception ex)
            {
                return Json(new { result = ex.Message }); ;

            }


        }


        [HttpPost]
        public ActionResult PostFile()
        {
            var file = Request.Form.Files[0];
            string folderName = "Product";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Json("Uploaded successully");
        }

    }
}

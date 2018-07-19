using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public ActionResult UserAdd([FromBody]JObject user)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(user);
                var temp = BsonDocument.Parse(jsonString);
                var collection = _db.GetCollection<BsonDocument>("User");
                collection.InsertOne(temp);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return Json(new { result = ex.Message }); ;

            }
        }


        [HttpPost]
        public ActionResult AddOffer([FromBody]JObject offer)
        {
            try
            { 
                string jsonString = JsonConvert.SerializeObject(offer);
                var temp = BsonDocument.Parse(jsonString);
                var collection = _db.GetCollection<BsonDocument>("Offer");
                collection.InsertOne(temp);
                return Json(new {});
            }
            catch (System.Exception ex)
            {
                return Json(new { result = ex.Message }); ;

            }
        }
        [HttpPost]
        public ActionResult PostFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var data = Request.Form["data"];
                var temp = BsonDocument.Parse(data);
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

                    temp = temp.Set("image", "Product/" + fileName);
                    temp = temp.Set("Time", DateTime.Now);
                    temp = temp.Set("SoldQuantity", 0);
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                var collection = _db.GetCollection<BsonDocument>("Product");
                collection.InsertOne(temp);
                return Ok(temp);
            }
            catch (System.Exception ex)
            {
                return Json(ex); ;
            }

        }
        [HttpGet]
        public ActionResult Populatedropdown()
        {
            try
            {
                var collection = _db.GetCollection<dynamic>("Product");
                var ProductList = collection.Find(new BsonDocument()).ToList().Select(x => new { id=x._id, name=x.ProductName});
                return Json(new { result=ProductList });
            }
            catch (System.Exception ex)
            {
                return Json(new { result = ex.Message }); ;

            }
        }

    }
}

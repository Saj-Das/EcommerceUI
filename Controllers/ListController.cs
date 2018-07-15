using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;
using Microsoft.AspNetCore.Hosting;
using Renova.Models;
namespace Renova.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ListController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        MongoClient _client;
        IMongoDatabase _db;


        public ListController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("Renova");
        }
      [HttpGet]
        public ActionResult getProduct() {
            
            try
            {   var collection = _db.GetCollection<dynamic>("Product");
                var ProductList =  collection.Find(new BsonDocument()).ToList();
                return Json(new { result =ProductList });
            }
            catch (System.Exception ex)
            {
                return Json(new { result =ex.Message }); ;

            }
        } 
[HttpGet]
        public ActionResult getUser() {
            
            try
            {   var collection = _db.GetCollection<dynamic>("User");
                var UserList =  collection.Find(new BsonDocument()).ToList();
                return Json(new { result =UserList });
            }
            catch (System.Exception ex)
            {
                return Json(new { result =ex.Message }); ;

            }
        } 
      
    }
}

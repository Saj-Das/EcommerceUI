using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Renova.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;
namespace Renova.Controllers
{
    [Route("api/[controller]")]
    public class productController : Controller
    {
        MongoClient _client;
        IMongoDatabase _db;

        public void DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("Renova");

        }

        [HttpPost]
        public ActionResult add(product product)
        {
            try
            {
                DataAccess();
                var collection = _db.GetCollection<product>("Product");
                collection.InsertOne(product);
                return Json(new { result = "done" });
            }
            catch (System.Exception ex)
            {
                return Json(new { result = ex.Message }); ;

            }


        }


    }
}

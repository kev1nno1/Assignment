using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [HttpGet("{orderId}")]
        public string GetOrder(string orderId)//add id parameter
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://api1:123@cluster0.nkkjht1.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings); var database = client.GetDatabase("OrderDB", default);
            
            
            var order = database.GetCollection<BsonDocument>("Order");
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            };

            //filter product with id
            var filter = Builders<BsonDocument>.Filter.Eq("OrderID", orderId);
            var order2 = order.Find(filter).Project(projection).ToList();
            

            var x = "";
            foreach (BsonDocument doc in order2)
            {
                x = doc.ToString();
            }
            
            //deserializing Json response from mongodb to C# object
            Order orderobject = JsonSerializer.Deserialize<Order>(x,options);
            
            return $"{orderobject.info()}";
        }
        

    }
}

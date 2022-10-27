using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Text;
using System.Text.Json;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateOrderController : Controller
    {
        [HttpPost]
        public async Task<string> CreateOrderAsync()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://api1:123@cluster0.nkkjht1.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("OrderDB", default);


            var order = database.GetCollection<BsonDocument>("Order");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            };

            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                Order orderobject = JsonSerializer.Deserialize<Order>(body, options);

                var json = JsonSerializer.Serialize(orderobject);
                var doc = BsonSerializer.Deserialize<BsonDocument>(json);
                order.InsertOne(doc);
                return $"The total bin width required for this order is: {orderobject.TotalBinWidth.ToString()} mm";


            }



            //ProductOrder order1 = new ProductOrder(3, "mug");
            //Order a = new Order("123",order1);
            //var x = JsonSerializer.Serialize(a);

        }
    }
}

using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // MongoDB veritabanına bağlanma
        var client = new MongoClient("mongodb://localhost:27017/");

        // Veritabanı ve koleksiyon oluşturma
        var database = client.GetDatabase("hakandatabase");
        var collection = database.GetCollection<BsonDocument>("customers");

        // Veri ekleme
        var data = new BsonDocument { { "name", "Hakan" }, { "address", "Maltepe" } };
        collection.InsertOne(data);

        // Veri ekleme sonucunu yazdırma
        Console.WriteLine(data["_id"]);
    }
}
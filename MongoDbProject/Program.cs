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
        
        //veri okuma
        var filter = Builders<BsonDocument>.Filter.Eq("name", "Hakan");
        var result = collection.Find(filter).FirstOrDefault();
        // Veri okuma sonucunu yazdırma
        Console.WriteLine(result.ToJson());
        //veri güncelleme
        var updateFilter = Builders<BsonDocument>.Filter.Eq("name", "Hakan");
        var update = Builders<BsonDocument>.Update.Set("address", "Kadıköy");
        var updateResult = collection.UpdateOne(filter, update);
        // Veri güncelleme sonucunu yazdırma
        Console.WriteLine("Güncellenen kayıt sayısı: " + updateResult.ModifiedCount);

        // Veri silme
        var deleteFilter = Builders<BsonDocument>.Filter.Eq("name", "Hakan");
        var deleteResult = collection.DeleteOne(filter);

        // Silme sonucunu yazdırma
        Console.WriteLine("Silinen kayıt sayısı: " + deleteResult.DeletedCount);
    }
}
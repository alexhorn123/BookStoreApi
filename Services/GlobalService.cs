using MissyMenuApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MissyMenuApi.Services;
public class GlobalService
{
    private readonly IMongoCollection<Global> _globalCollection;

    public GlobalService(
        IOptions<MissyMenuDatabaseSettings> missyMenuDatabaseSettings)
    {
        var mongoClient = new MongoClient(
        missyMenuDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            missyMenuDatabaseSettings.Value.DatabaseName);

        _globalCollection = mongoDatabase.GetCollection<Global>("Global");
    }

    public async Task<List<Global>> GetAsync() =>
        await _globalCollection.Find(_ => true).ToListAsync();
    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public async Task<Global?> GetAsync(string id) =>
        await _globalCollection.Find(x => x._id.Oid == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Global newGlobal) =>
        await _globalCollection.InsertOneAsync(newGlobal);

    public async Task UpdateAsync(string id, Global updatedGlobal) =>
        await _globalCollection.ReplaceOneAsync(x => x._id.Oid == id, updatedGlobal);

    public async Task RemoveAsync(string id) =>
        await _globalCollection.DeleteOneAsync(x => x._id.Oid == id);
}

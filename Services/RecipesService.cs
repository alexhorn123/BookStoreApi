using MissyMenuApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MissyMenuApi.Services;

public class RecipesService
{
    private readonly IMongoCollection<Recipe> _recipesCollection;

    public RecipesService(
        IOptions<MissyMenuDatabaseSettings> missyMenuDatabaseSettings)
    {
        var mongoClient = new MongoClient(
        missyMenuDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            missyMenuDatabaseSettings.Value.DatabaseName);

        _recipesCollection = mongoDatabase.GetCollection<Recipe>("Recipes");
    }

    public async Task<List<Recipe>> GetAsync() =>
        await _recipesCollection.Find(_ => true).ToListAsync();
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public async Task<Recipe?> GetAsync(string id) =>
        await _recipesCollection.Find(x => x._id.Oid == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Recipe newRecipe) =>
        await _recipesCollection.InsertOneAsync(newRecipe);

    public async Task UpdateAsync(string id, Recipe updatedRecipe) =>
        await _recipesCollection.ReplaceOneAsync(x => x._id.Oid == id, updatedRecipe);

    public async Task RemoveAsync(string id) =>
        await _recipesCollection.DeleteOneAsync(x => x._id.Oid == id);
}
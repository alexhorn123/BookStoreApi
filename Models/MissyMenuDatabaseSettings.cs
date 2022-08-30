namespace MissyMenuApi.Models;

public class MissyMenuDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string RecipesCollectionName { get; set; } = null!;
}
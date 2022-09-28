 //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Id
    {
        public string Oid { get; set; } = null!;
    }

    public class Ingredient
    {
        public string IngredientName { get; set; } = null!;
        public string Measurement { get; set; } = null!;
        public string Note { get; set; } = null!;
        public string Link { get; set; } = null!;
    }

    public class Direction
    {
        public string Step { get; set; } = null!;
    }

    public class Recipe
    {
        public Id _id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<Ingredient> Ingredients { get; set; } = null!;
        public List<Direction> Directions { get; set; } = null!;
}


namespace MissyMenuApi.Models
{

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Gid
        {
            public string? Oid { get; set; }
        }

        public class Global
        {
            public Gid? _id { get; set; }
            public string? Config_Name { get; set; }
            public string? Config_Value { get; set; }
            public string? Config_Description { get; set; }
            public string? Config_Enabled { get; set; }
        }


    }

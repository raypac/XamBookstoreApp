using System.Collections.Generic;

namespace XamBookstoreApp.Mob.Utilities
{
    public static class StaticDefinition
    {
        public static List<string> CategoryList = new List<string>(new[] { "Category 1", "Category 2", "Category 3" });

        public static string BaseAPI = "https://raypac-bs-api.azurewebsites.net";

        public static string EndPoint = "api/Book";
    }
}

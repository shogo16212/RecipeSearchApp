using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeSearchApp
{
    public static class Common
    {
        public static void Show(this string message)
        {
            MessageBox.Show(message);
        }
        public static void Err(this string message)
        {
            throw new Exception(message);
        }
        public static bool IsNullOrEmpty(this string message)
        {
            return string.IsNullOrEmpty(message);
        }

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };

        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, options);
        }
        public static T FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}

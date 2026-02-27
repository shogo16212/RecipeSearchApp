using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSearchApp
{
    public static class Api
    {

        private static async Task<T> Request<T>(string arg, HttpMethod method, string json = "")
        {
            var url = $"https://openapi.rakuten.co.jp/recipems/api/Recipe/{arg}";
            var req = new HttpRequestMessage(method, url);

            using (HttpClient client = new HttpClient())
            {
                if (!json.IsNullOrEmpty())
                {
                    req.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                var res = await client.SendAsync(req);
                var body = await res.Content.ReadAsStringAsync();

                var code = (int)res.StatusCode;

                if (code != 200 && code != 201 && code != 204)
                {
                    throw new ApiException(code, res.ReasonPhrase ?? "", body);
                }

                return body.FromJson<T>();
            }
        }

        public static Task<T> Get<T>(string arg)
        {
            return Request<T>(arg, HttpMethod.Get);
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
/**
 * Heavily references: https://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
 */
namespace decal.Calendar.API
{
    public static class API
    {
        private const string URL = "decalwallcalendar.com/api/";
        private static HttpClient client = new HttpClient();

        static API()
        {
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //AUTHENTICATE method

        internal static async Task<T> GetAsync<T>(string path)
        {
            T item = default(T);
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<T>();
            }
            return item;
        }

        internal static async Task<R> CreateAsync<T, R>(string path, T item)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, item);
            response.EnsureSuccessStatusCode();

            // Return the URI of the created resource.
            return await response.Content.ReadAsAsync<R>();
        }

        internal static async Task<T> UpdateAsync<T>(string path, T item)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(path, item);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            item = await response.Content.ReadAsAsync<T>();
            return item;
        }

        internal static async Task<HttpStatusCode> DeleteAsync(string path)
        {
            HttpResponseMessage response = await client.DeleteAsync(path);
            return response.StatusCode;
        }
    }
}

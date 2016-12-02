using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Model = decal.Calendar;

namespace decal.Calendar.API
{
    static class Client
    {
        static string method = "/client/";

        public async static Task<Model.Client> Get(int id)
        {
            UriBuilder url = new UriBuilder(method);
            string query;
            using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]{
                new KeyValuePair<string, string>("id", id.ToString())
            }))
            {
                query = content.ReadAsStringAsync().Result;
            }

            url.Query = query.ToString();

            return await API.GetAsync<Model.Client>(url.Uri.ToString());
        }

        public async static Task<int> Add(Model.Client appt)
        {
            return await API.CreateAsync<Model.Client, int>(method, appt);
        }

        public static async Task<Model.Client> Update(Model.Client appt)
        {
            return await API.UpdateAsync(method, appt);
        }

        public static async Task<bool> Delete(int id)
        {
            string path = String.Format("{0}/{1}", method, id);
            HttpStatusCode response = await API.DeleteAsync(path);
            return response.HasFlag(HttpStatusCode.OK);
        }
    }
}

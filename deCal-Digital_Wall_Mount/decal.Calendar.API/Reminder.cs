using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Model = decal.Calendar;

namespace decal.Calendar.API
{
    static class Reminder
    {
        static string method = "/reminder/";

        public async static Task<Model.Reminder> Get(int id)
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

            return await API.GetAsync<Model.Reminder>(url.Uri.ToString());
        }

        public async static Task<Model.Reminder[]> GetAllForAppointment(int apptId)
        {
            UriBuilder url = new UriBuilder(method);
            string query;
            using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]{
                new KeyValuePair<string, string>("appt-id", apptId.ToString())
            }))
            {
                query = content.ReadAsStringAsync().Result;
            }

            url.Query = query.ToString();

            return await API.GetAsync<Model.Reminder[]>(url.Uri.ToString());
        }

        public async static Task<int> Add(Model.Reminder appt)
        {
            return await API.CreateAsync<Model.Reminder, int>(method, appt);
        }

        public static async Task<Model.Reminder> Update(Model.Reminder appt)
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

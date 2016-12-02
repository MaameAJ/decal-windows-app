using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Model = decal.Calendar;

namespace decal.Calendar.API
{
    public static class Appointment
    {
        static string method = "/appointment/";

        public async static Task<Model.Appointment> Get(int id)
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

            return await API.GetAsync<Model.Appointment>(url.Uri.ToString());
        }

        public async static Task<Model.Appointment[]> Get(DateTime date)
        {
            UriBuilder url = new UriBuilder(method);
            string query;
            using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]{
                new KeyValuePair<string, string>("date", date.ToString()), //TODO figure out how to format this date
                new KeyValuePair<string, string>("time", date.ToString()) //TODO figure out how to format this time
            }))
            {
                query = content.ReadAsStringAsync().Result;
            }

            url.Query = query.ToString();

            return await API.GetAsync<Model.Appointment[]>(url.Uri.ToString());
        }

        public async static Task<int> Add(Model.Appointment appt)
        {
            return await API.CreateAsync<Model.Appointment, int>(method, appt);
        }

        public static async Task<Model.Appointment> Update(Model.Appointment appt)
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

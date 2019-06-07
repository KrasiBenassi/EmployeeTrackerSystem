using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.ArrivalService
{
    public class EmployeeArrivalServicecs : IEmployeeArrivalServicecs
    {
        private const string SubscribtionUrlFormat = "http://localhost:51396/api/clients/subscribe?date={0}&callback={1}";

        public EmployeeArrivalServicecs()
        {
        }

        public async Task<string> Subscribe(DateTime date, string callbackUrl)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept-Client", "Fourth-Monitor");

            var dateAsString = date.ToString("yyyy-MM-dd");
            var url = string.Format(SubscribtionUrlFormat, dateAsString, callbackUrl);
            var response = await Task.Run(() => client.GetAsync(url));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return content;
            }

            return string.Empty;
        }
    }
}

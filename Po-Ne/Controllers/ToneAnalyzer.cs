using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Po_Ne.Controllers
{
    public static class ToneAnalyzer
    {

        public static String getToneAnalysis(String scorecard, String body)
        {
            string result = "";
            using (var client = new WebClient())
            {
                String userName = "f2f8a4ad-f87c-487a-85fe-92a8d150944e";
                String password = "QUSjnSsOtgEU";

                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + password));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
                client.Headers[HttpRequestHeader.ContentType] = "text/plain";
                result = client.UploadString("https://gateway.watsonplatform.net/tone-analyzer-experimental/api/v1/tone", body);

                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                
                return values["id"];
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Watson
{
    class ToneAnalyzer
    {

        public static void getToneAnalysis(String scorecard, String body)
        {
            string result = "";
            using (var client = new WebClient())
            {
                String userName = "f2f8a4ad-f87c-487a-85fe-92a8d150944e";
                String password = "QUSjnSsOtgEU";
                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + password));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
                //"{\"scorecard\":\"test\",\"text\":\"I am sad\"}"
                String json = "I am sad";
                client.Headers[HttpRequestHeader.ContentType] = "text/plain";
                result = client.UploadString("https://gateway.watsonplatform.net/tone-analyzer-experimental/api/v1/tone", json);


                var resultJson = JsonConvert.DeserializeObject(result);
                Console.WriteLine(resultJson);
            }
        }

        public static void Main()
        {
            getToneAnalysis("test", "I am sad");
        }

    }
}

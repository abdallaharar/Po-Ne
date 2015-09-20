using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace Po_Ne.Controllers
{
    public class emotion
    {
        public string name { get; set; }
        public string id { get; set; }
        public int word_count { get; set; }
        public double normalize_score { get; set; }
        public double raw_score { get; set; }
        public string words { get; set; }
        public double evidence_score { get; set; }


        public override string ToString()
        {
            string emotion = "";

            emotion = "EMOTION {" + name + " " + id + " " + word_count + " " + normalize_score + " " + raw_score + " " + evidence_score + " "+ words + "}. "; 
            return emotion;
        }
        public emotion() { }
        public emotion(string name, string id, int word_count, double normalize_score, double raw_score, double evidence_score, string words)
        {
            this.name = name;
            this.id = id;
            this.word_count = word_count;
            this.normalize_score = normalize_score;
            this.raw_score = raw_score;
            this.evidence_score = evidence_score;
            this.words = words; 
        }


    }

    public static class ToneAnalyzer
    {

        public static List<emotion> getToneAnalysis(String scorecard, String body)
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



                var root = JObject.Parse(result.ToString());
                var children = root["children"];

                List<emotion> emotions = new List<emotion>();
                    
                    var children2 = children[0]["children"][2];
                    var evidence_score = (double)children2["linguistic_evidence"][0]["evidence_score"];
                    string words = children2["linguistic_evidence"][0]["words"].ToString();
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double) children2["linguistic_evidence"][0]["evidence_score"], words));

                    children2 = children[0]["children"][1];
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"],(double) children2["linguistic_evidence"][0]["evidence_score"], words));

                    children2 = children[0]["children"][0];
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double) children2["linguistic_evidence"][0]["evidence_score"], words));


                    children2 = children[1]["children"][2];
                    evidence_score = (double)children2["linguistic_evidence"][0]["evidence_score"];
                    words = children2["linguistic_evidence"][0]["words"].ToString();
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double)children2["linguistic_evidence"][0]["evidence_score"], words));

                    children2 = children[1]["children"][1];
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double)children2["linguistic_evidence"][0]["evidence_score"], words));

                    children2 = children[1]["children"][0];
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double)children2["linguistic_evidence"][0]["evidence_score"], words));


                    children2 = children[2]["children"][2];
                    evidence_score = (double)children2["linguistic_evidence"][0]["evidence_score"];
                    words = children2["linguistic_evidence"][0]["words"].ToString();
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double)children2["linguistic_evidence"][0]["evidence_score"], words));

                    children2 = children[2]["children"][1];
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double)children2["linguistic_evidence"][0]["evidence_score"], words));

                    children2 = children[2]["children"][0];
                    emotions.Add(new emotion(children2["name"].ToString(), children2["id"].ToString(), (int)children2["word_count"], (double)children2["normalized_score"], (double)children2["raw_score"], (double)children2["linguistic_evidence"][0]["evidence_score"], words));
                   
                    return emotions;
            }
        }

  
    }
}

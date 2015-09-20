using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Po_Ne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {

            return View();
        }

        public JsonResult RetrieveWatsonFeedback(string dataRequest)
        {
            Po_Ne.Controllers.Client twitter = new Po_Ne.Controllers.Client();
            var variable = "?q=" + dataRequest + "&result_type=popular&lang=en&count=99";
            var twitResponceJson = twitter.GetSearchJson(twitter.GetBearerToken(), variable.ToString());
            dynamic stuff = JsonConvert.DeserializeObject(twitResponceJson);
            var twitStatus = stuff.statuses;
            string test = "";
            foreach (var text in twitStatus) {
                test += text.text;
            }
            var percentage = Po_Ne.Controllers.ToneAnalyzer.judge(test);
            return Json(percentage);
        }
    }
}
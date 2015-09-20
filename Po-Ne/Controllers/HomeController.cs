﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var variable = "?q=" + dataRequest + "&result_type=recent&lang=en";
            ViewData["WatsonResult"] = twitter.GetSearchJson(twitter.GetBearerToken(), variable.ToString());
            var percentage = Po_Ne.Controllers.ToneAnalyzer.judge(ViewData["WatsonResult"].ToString());
            return Json(percentage);
        }
    }
}
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
            return Json(dataRequest);
        }
    }
}
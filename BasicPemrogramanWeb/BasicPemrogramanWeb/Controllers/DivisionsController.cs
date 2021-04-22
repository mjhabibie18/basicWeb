using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BasicPemrogramanWeb.Controllers
{
    public class DivisionsController : Controller
    {
        // GET: Divisions
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:50025/API/")
        };
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadDivision()
        {
            IEnumerable<Division> divisions = null;
            var responseTask = client.GetAsync("Divisions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Division>>();
                readTask.Wait();
                divisions = readTask.Result;
            }
            return new JsonResult
            {
                Data = divisions,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
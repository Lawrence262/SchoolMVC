using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SchoolMVC.Models;
namespace SchoolMVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            IEnumerable<StudentsModel> studdata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44374/api/";

                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<StudentsModel>>(json);
                studdata = list.ToList();
                return View(studdata);
            }
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
           StudentsModel studdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44374/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                studdata = JsonConvert.DeserializeObject<StudentsModel>(json);
            }
            return View(studdata);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(StudentsModel model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44374/api/";
                    var url = "Students/POST";
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<StudentsModel>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            StudentsModel studdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44374/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                studdata = JsonConvert.DeserializeObject<StudentsModel>(json);
            }
            return View(studdata);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentsModel model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44374/api/Students/" + id;
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);
                    StudentsModel modeldata = JsonConvert.DeserializeObject<StudentsModel>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            StudentsModel studdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44374/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                studdata = JsonConvert.DeserializeObject<StudentsModel>(json);
            }
            return View(studdata);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentsModel model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection nv = new NameValueCollection();

                    var url = "https://localhost:44374/api/Students/" + id;
                    var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");

        }
    }
}

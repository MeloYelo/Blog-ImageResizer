using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageResizer;

namespace ImageResizerPlayground.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

		  [HttpPost]
		  public ActionResult Upload(HttpPostedFileBase file)
		  {
			  if (file != null && file.ContentLength > 0)
			  {
				  var job = new ImageJob(file, "~/images/<guid>", new Instructions("mode=max;format=jpg;width=400;height=400;"));
				  job.CreateParentDirectory = true;
				  job.AddFileExtension = true;
				  job.Build();
				  string fileName = Path.GetFileName(job.FinalPath);
				  ViewBag.ImageUrl = Url.Content("~/images/" + fileName);
				  ViewBag.FileName = fileName;
			  }
			  return View();
		  }
	}
}
using MeHasVisto.Models;
using MeHasVisto.Models.Bussines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeHasVisto.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {

            var name = (string)RouteData.Values["id"];
            //var model = PetManagenmet.GetByBame(name);
            if (null == null)
            {
                return RedirectToAction("NoTFound");
                //return View(model);
            }
        }

        public ActionResult NotFound() 
        {
            /*ViewData["ErrorCode"] = "NFE0001";
            ViewData["Description"]="La mascota no se encuentra "+"en la base de datos";
            return View();*/
            ViewBag.ErrorCode= "NFE0001";
            ViewBag.Description = "La mascota no se encuentra " + "en la base de datos";
            return View();
        
        }

        public FileResult DownLoadPicture() 
        {

            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/"+ name + ".jpg";
            var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture, contentType, fileName);
        }

        public HttpStatusCodeResult UnauthorizedError()
        {
            return new HttpUnauthorizedResult("Error de acesso");
        }
        public ActionResult NotFoundError()
        {
            return HttpNotFound("Nada por aqui");
        }
        public ActionResult PictureUpload()
        {

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if (model.PictureFile.ContentLength > 0)
            {
                var fileName =
                    Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string savedFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(savedFileName);
                PetManagement.CreateThumbnail(fileName, filePath, 100, 100, true);

            }
            return View(model);
        }
    }
    
}

using BookingSystemDLS.DataModel.Master.Resource;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using BookingSystemDLS.DataModel.Master.resource;
using System.Transactions;
using BookingSystemDLS.DataModel.Master.resourceDetail;
using BookingSystemDLS.DataModel.Master.ResourceDetail;

namespace BookingSystemDLS.WEB.Controllers
{
    [Route("Resource")]
    public class ResourceWebController : Controller
    {
        private readonly ResourceProvider _ResourceProvider;
        private readonly ResourceDetailProvider _ResourceDetailProvider;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public ResourceWebController(ResourceProvider provider, ResourceDetailProvider resourceDetailProvider, IWebHostEnvironment webHostEnvironment)
        {
            _ResourceProvider = provider;
            _ResourceDetailProvider = resourceDetailProvider;
            _WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var Resources = _ResourceProvider.getAll();

            return View("Resource-Index", Resources);
        }

      

        [HttpGet("Add")]
        public IActionResult addForm()
        {
            var Resource = new ResourceWithDetailVM();
            var list = new List<GridResourceDetailVM>();
            Resource.details = list;
            
            return View("Resource-Upsert", Resource);
        }


        [HttpGet("Edit/{id}")]
        public IActionResult EditForm(int id) 
        {
            
            var resource = _ResourceProvider.getSingle(id);
            var details = _ResourceDetailProvider.getByResourceID(id);

            var response = new ResourceWithDetailVM();
            response.Name = resource.Name;
            response.Id = resource.Id;
            response.IsActive = resource.IsActive;
            response.IconPath = resource.IconPath;
            response.details = details;

            return View("Resource-Upsert", response);
        }


        [HttpPost("Upsert")]
        public IActionResult Upsert(ResourceWithDetailVM model)
        {
            /*if (model.IconFile != null || model.IconFile.Length != 0)
            {
                var uploadsFolder = Path.Combine(_WebHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.IconFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                *//*using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.IconFile.CopyToAsync(fileStream);
                }*//*

                // Set IconPath ke jalur file yang disimpan
                model.IconPath = $"/uploads/{uniqueFileName}";

                ViewBag.Message = "File berhasil diupload!";
                ViewBag.FilePath = model.IconPath;
            }*/

            var item = new UpsertResourceVM();
            item.Name = model.Name;
            item.Id = model.Id;
            item.IconPath = model.IconPath;
            item.IsActive = model.IsActive;

            if (model.Id == 0)
            {
                _ResourceProvider.insert(item);
            }
            else
            {
                _ResourceProvider.update(item);
            }

            /*foreach (var dtl in model.details)
            {
                if(dtl.Id == 0)
                {
                    var upsertDtl = new UpsertResourceDetailVM();
                    upsertDtl.Code = dtl.Code;
                    upsertDtl.Id = dtl.Id;
                    upsertDtl.IsActive = dtl.IsActive;
                    upsertDtl.ResourceId = model.Id;
                    _ResourceDetailProvider.insert(upsertDtl);
                }
                else
                {
                    var upsertDtl = _ResourceDetailProvider.getSingleUpsert(dtl.Id);
                    upsertDtl.Code = dtl.Code;
                    upsertDtl.Id = dtl.Id;
                    upsertDtl.IsActive = dtl.IsActive;
                    upsertDtl.ResourceId = model.Id;
                    _ResourceDetailProvider.update(upsertDtl);
                }
            }*/

            return RedirectToAction("Index");
        }


        [HttpPost("Delete")]
        public IActionResult Delete(int id) {
            _ResourceProvider.delete(id);

            return RedirectToAction("Index");
        }
    }
}

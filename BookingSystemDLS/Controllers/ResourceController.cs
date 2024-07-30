using BookingSystemDLS.DataModel.Master.resource;
using BookingSystemDLS.DataModel.Master.Resource;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private ResourceProvider ResourceProvider;
        private ResourceDetailProvider ResourceDetailProvider;
        public ResourceController(ResourceProvider ResourceProvider, ResourceDetailProvider ResourceDetailProvider)
        {
            this.ResourceProvider = ResourceProvider;
            this.ResourceDetailProvider = ResourceDetailProvider;
        }

        [HttpGet]
        public ActionResult getAll()
        {
            try
            {
                return Ok(ResourceProvider.getAll());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult getSingle(int id)
        {
            try
            {
                return Ok(ResourceProvider.getSingle(id));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}/detail")]
        public ActionResult getdetails(int id)
        {
            try
            {
                var resource = ResourceProvider.getSingle(id);
                var details = ResourceDetailProvider.getByResourceID(id);

                var response = new ResourceWithDetailVM();
                response.Name = resource.Name;
                response.Id = resource.Id;
                response.IconPath = resource.IconPath;
                response.details = details;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult upsert(UpsertResourceVM model)
        {
            try
            {
                if (model.Id == 0)
                {
                    ResourceProvider.insert(model);
                }
                else
                {
                    ResourceProvider.update(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                ResourceProvider.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

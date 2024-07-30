using BookingSystemDLS.DataModel.Master.resource;
using BookingSystemDLS.DataModel.Master.resourceDetail;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceDetailController : ControllerBase
    {
        private ResourceDetailProvider ResourceDetailProvider;
        public ResourceDetailController( ResourceDetailProvider ResourceDetailProvider)
        {
            this.ResourceDetailProvider = ResourceDetailProvider;
        }

        [HttpPost]
        public ActionResult upsert(UpsertResourceDetailVM model)
        {
            try
            {
                if (model.Id == 0)
                {
                    ResourceDetailProvider.insert(model);
                }
                else
                {
                    ResourceDetailProvider.update(model);
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
                ResourceDetailProvider.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

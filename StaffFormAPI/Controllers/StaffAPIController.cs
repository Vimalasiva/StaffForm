using Microsoft.AspNetCore.Mvc;
using StaffForm.Core.IService;
using StaffForm.Core.Model;
using StaffForm.Services;

namespace StaffFormAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffAPIController : Controller
    {
        private readonly IStaffService staffService ;

        public StaffAPIController(IStaffService staffService)
        {
            this.staffService = staffService;
        }
        #region Create
        [HttpPost]
        public IActionResult Create(StaffModel staffModel)
        {
            staffService.Createform(staffModel);
            return Ok(staffModel);
        }
        #endregion

        #region List
        [HttpGet]
        public IActionResult List()
        {
            var list = staffService.listform();
            return Ok(list);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = staffService.Save(id);
            return Ok(edit);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            staffService.deleteid(id);
            return Ok();
        }
        #endregion
    }
}

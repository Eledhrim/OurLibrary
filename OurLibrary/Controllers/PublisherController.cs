using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurLibrary.DataAccess.Repository.IRepository;

namespace OurLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PublisherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublisherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Publisher.GetAll() });
            //Stored Procedure Version
            //return Json(new { data = _unitOfWork.SP_Call.ReturnList<Category>("usp_GetAllCategory", null) });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Publisher.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Publisher.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Successfully deleted" });
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurLibrary.DataAccess.Repository.IRepository;

namespace OurLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Author.GetAll() });
            //Stored Procedure Version
            //return Json(new { data = _unitOfWork.SP_Call.ReturnList<Category>("usp_GetAllCategory", null) });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Author.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Successfully deleted" });
        }

    }
}
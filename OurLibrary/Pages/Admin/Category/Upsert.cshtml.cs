using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.DataAccess.Repository.IRepository;

namespace OurLibrary.Pages.Admin
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public OurLibrary.Models.Category CategoryObj { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IActionResult OnGet(int? id)
        {
            CategoryObj = new OurLibrary.Models.Category();

            if (id != null)
            {
                CategoryObj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

                if (CategoryObj == null)
                    return NotFound();
            }

            CategoryList = _unitOfWork.Category.GetCategoryListForDropDown();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (CategoryObj.Id == 0)
            {
                _unitOfWork.Category.Add(CategoryObj);
            }
            else
            {
                _unitOfWork.Category.Update(CategoryObj);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}
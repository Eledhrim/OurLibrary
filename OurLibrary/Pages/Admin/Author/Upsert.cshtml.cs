using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.DataAccess.Repository.IRepository;

namespace OurLibrary.Pages.Admin.Author
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public OurLibrary.Models.Author AuthorObj { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> AuthorList { get; set; }

        public IActionResult OnGet(int? id)
        {
            AuthorObj = new OurLibrary.Models.Author();

            if (id != null)
            {
                AuthorObj = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);

                if (AuthorObj == null)
                    return NotFound();
            }

            AuthorList = _unitOfWork.Author.GetAuthorListForDropDown();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AuthorObj.Id == 0)
            {
                _unitOfWork.Author.Add(AuthorObj);
            }
            else
            {
                _unitOfWork.Author.Update(AuthorObj);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}
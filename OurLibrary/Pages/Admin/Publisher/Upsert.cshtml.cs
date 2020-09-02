using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.DataAccess.Repository.IRepository;

namespace OurLibrary.Pages.Admin.Publisher
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public OurLibrary.Models.Publisher PublisherObj { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> PublisherList { get; set; }

        public IActionResult OnGet(int? id)
        {
            PublisherObj = new OurLibrary.Models.Publisher();

            if (id != null)
            {
                PublisherObj = _unitOfWork.Publisher.GetFirstOrDefault(u => u.Id == id);

                if (PublisherObj == null)
                    return NotFound();
            }

            PublisherList = _unitOfWork.Publisher.GetPublisherListForDropDown();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (PublisherObj.Id == 0)
            {
                _unitOfWork.Publisher.Add(PublisherObj);
            }
            else
            {
                _unitOfWork.Publisher.Update(PublisherObj);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}
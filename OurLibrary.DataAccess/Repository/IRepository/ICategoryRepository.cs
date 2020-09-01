using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurLibrary.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}

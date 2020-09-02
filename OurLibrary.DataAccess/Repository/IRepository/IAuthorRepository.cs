using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurLibrary.DataAccess.Repository.IRepository
{
    public interface IAuthorRepository:IRepository<Author>
    {
        IEnumerable<SelectListItem> GetAuthorListForDropDown();

        void Update(Author author);
    }
}

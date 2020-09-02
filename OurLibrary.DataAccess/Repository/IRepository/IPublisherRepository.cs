using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurLibrary.DataAccess.Repository.IRepository
{
    public interface IPublisherRepository:IRepository<Publisher>
    {
        IEnumerable<SelectListItem> GetPublisherListForDropDown();

        void Update(Publisher publisher);
    }
}

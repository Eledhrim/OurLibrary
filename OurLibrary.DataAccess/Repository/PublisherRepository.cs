using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.DataAccess.Repository.IRepository;
using OurLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurLibrary.DataAccess.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        private readonly ApplicationDbContext _db;

        public PublisherRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetPublisherListForDropDown()
        {
            return _db.Publisher.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            
        }

        public void Update(Publisher publisher)
        {
            var objFromDb = _db.Publisher.FirstOrDefault(c => c.Id == publisher.Id);

            objFromDb.Name = publisher.Name;
            

            _db.SaveChanges();
        }
    }
}

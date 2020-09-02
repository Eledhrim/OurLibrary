using Microsoft.AspNetCore.Mvc.Rendering;
using OurLibrary.DataAccess.Repository.IRepository;
using OurLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurLibrary.DataAccess.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetAuthorListForDropDown()
        {
            return _db.Author.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            
        }

        public void Update(Author author)
        {
            var objFromDb = _db.Author.FirstOrDefault(c => c.Id == author.Id);

            objFromDb.Name = author.Name;
            

            _db.SaveChanges();
        }
    }
}

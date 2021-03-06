﻿using System;
using System.Collections.Generic;
using System.Text;
using OurLibrary.DataAccess.Repository.IRepository;

namespace OurLibrary.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Category = new CategoryRepository(_db);
            Author = new AuthorRepository(_db);
            Publisher = new PublisherRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IAuthorRepository Author { get; private set; }
        public IPublisherRepository Publisher { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

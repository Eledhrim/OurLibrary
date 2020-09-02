using System;
using System.Collections.Generic;
using System.Text;

namespace OurLibrary.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        IAuthorRepository Author { get; }

        IPublisherRepository Publisher { get; }
        void Save();
    }
}

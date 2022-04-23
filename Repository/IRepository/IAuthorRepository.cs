using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Repository.IRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> Get(int? Id);
        Task<bool> Create(Author entity);
        Task<bool> Update(Author entity);
        Task<bool> Delete(Author entity);

        bool Save();
        Task<bool> SaveAsync();
    }
}

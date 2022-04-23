using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<List<Author>> GetAll()
        {
            return await _db.Author.OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<Author> Get(int? Id)
        {

            return await _db.Author.FindAsync(Id);
        }

        public async Task<bool> Create(Author entity)
        {
            await _db.Author.AddAsync(entity);
            return Save();
        }

        public async Task<bool> Update(Author entity)
        {
            _db.Author.Update(entity);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Author entity)
        {
            _db.Author.Remove(entity);
            return await SaveAsync();
        }

        public async Task<Author> FindById(int id)
        {
            return await _db.Author.FindAsync(id);
        }

        //public async Task<bool> Exist(int Id)
        //{
        //    return await _db.Book.AnyAsync(b => b.Id == Id);
        //}




        // Methods to commit the changes to the database
        public  bool Save()
        {
            return  _db.SaveChanges() >= 0 ? true : false;
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

    }
}

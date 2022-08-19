using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameApi.Services
{
    public class UserService : IUserService
    {
        private MyContext _dbContext;

        public UserService(MyContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IList<Account>> ListAsync()
        {
            IList<Account> result = new List<Account>();
            try
            {
                var fromDB = from d in _dbContext.Accounts
                             select d;

                if (await fromDB.AnyAsync())
                {
                    result = await fromDB.ToListAsync();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                throw;
            }
            return result;
        }


        public async Task<Account> GetByIdAsync(int id)
        {
            Account result = null;
            try
            {
                var fromDb = from d in _dbContext.Accounts
                             where d.id == id
                             select d;

                if (await fromDb.AnyAsync())
                {
                    result = await fromDb.FirstOrDefaultAsync();
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                throw;
            }

            return result;
        }

        public async Task<bool> InsertAsync(Account account)
        {
            bool result = false;
            try
            {
                await _dbContext.Accounts.AddAsync(account);

                result = (await _dbContext.SaveChangesAsync() > 0);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }

            return result;
        }
        
        public async Task<bool> UpdateAsync(Account account)
        {
            bool result = false;
            try
            {
                var fromDb = from d in _dbContext.Accounts
                             where d.id == account.id
                             select d;
                if (await fromDb.AnyAsync())
                {
                    var entiy = await fromDb.FirstOrDefaultAsync();
                    
                    //entiy.username = account.username;  //理論上無法修改
                    entiy.password = account.password;
                    entiy.nickname = account.nickname;

                    result = await _dbContext.SaveChangesAsync() > 0;
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                throw;
            }

            return result;
        }

        public async Task<bool> DeleteAsync(Account account)
        {
            return await DeleteAsync(account.id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            try
            {
                var fromDb = from d in _dbContext.Accounts
                             where d.id == id
                             select d;
                if (await fromDb.AnyAsync())
                {
                    var entiy = await fromDb.FirstOrDefaultAsync();
                    _dbContext.Accounts.Remove(entiy);
                    result = await _dbContext.SaveChangesAsync() > 0;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                throw;
            }

            return result;
        }
    }

    public interface IUserService
    {
        Task<IList<Account>> ListAsync();
        Task<Account> GetByIdAsync(int id);

        Task<bool> InsertAsync(Account account);

        Task<bool> UpdateAsync(Account account);

        Task<bool> DeleteAsync(Account account);
        Task<bool> DeleteAsync(int id);

    }
}

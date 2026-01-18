using FUNewsManagementSystem.Repository.GenericRepo;
using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Repository.Repositories.IRepository
{
    public interface ISystemAccountRepository : IGenericRepository<SystemAccount>
    {
        Task<SystemAccount> GetByEmailAsync(string email);
        Task<SystemAccount> GetByEmailAndPasswordAsync(string email, string password);
        Task<List<SystemAccount>> GetAccountsByRoleAsync(int role);
        Task<bool> IsEmailExistAsync(string email);
    }
}
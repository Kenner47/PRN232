using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Service.Services.IServices
{
    public interface ISystemAccountService
    {
        Task<List<SystemAccount>> GetAllAccountsAsync();
        Task<SystemAccount> GetAccountByIdAsync(int id);
        Task<SystemAccount> GetByEmailAsync(string email);
        Task<SystemAccount> LoginAsync(string email, string password);
        Task<List<SystemAccount>> GetAccountsByRoleAsync(int role);
        Task<bool> CreateAccountAsync(SystemAccount account);
        Task<bool> UpdateAccountAsync(SystemAccount account);
        Task<bool> DeleteAccountAsync(int id);
        Task<bool> IsEmailExistAsync(string email);
    }
}
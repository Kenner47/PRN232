using FUNewsManagementSystem.Repository.GenericRepo;
using FUNewsManagementSystem.Repository.Models;
using FUNewsManagementSystem.Repository.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        INewsArticleRepository NewsArticleRepository { get; }
        ISystemAccountRepository SystemAccountRepository { get; }
        ITagRepository TagRepository { get; }

        IGenericRepository<T> Repository<T>() where T : class;

        Task<int> SaveAsync();
        int Save();

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        void Save();
    }
}

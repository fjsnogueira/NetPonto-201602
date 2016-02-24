namespace NetPontoSec.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<TModel> where TModel : class
    {
        TModel Add(TModel t);
        void Delete(Func<TModel, bool> match);
        TModel Find(Func<TModel, bool> match);
        IEnumerable<TModel> FindAll(Func<TModel, bool> match);
        Task<IEnumerable<TModel>> FindAllAsync(Func<TModel, bool> match);
        Task<TModel> FindAsync(Func<TModel, bool> match);
        IEnumerable<TModel> GetAll();
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
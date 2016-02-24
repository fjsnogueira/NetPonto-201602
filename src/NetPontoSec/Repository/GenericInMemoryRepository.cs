namespace NetPontoSec.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        protected readonly List<TModel> Context;

        protected GenericRepository()
        {
            this.Context = new List<TModel>();
        }

        protected GenericRepository(List<TModel> contex)
        {
            this.Context = contex;
        }

        public TModel Add(TModel t)
        {
            this.Context.Add(t);
            return t;
        }

        public void Delete(Func<TModel, bool> match)
        {
            TModel toRemove = this.Context.FirstOrDefault(match);
            if (toRemove != null)
            {
                this.Context.Remove(toRemove);
            }
        }

        public TModel Find(Func<TModel, bool> match)
        {
            return this.Context.FirstOrDefault(match);
        }

        public Task<TModel> FindAsync(Func<TModel, bool> match)
        {
            return Task.FromResult(this.Find(match));
        }

        public IEnumerable<TModel> FindAll(Func<TModel, bool> match)
        {
            return this.Context.Where(match);
        }

        public Task<IEnumerable<TModel>> FindAllAsync(Func<TModel, bool> match)
        {
            return Task.FromResult(this.FindAll(match));
        }

        public IEnumerable<TModel> GetAll()
        {
            return this.Context;
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            return Task.FromResult(this.GetAll());
        }
    }

}

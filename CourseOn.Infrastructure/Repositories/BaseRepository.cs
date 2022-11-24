using CourseOn.Domain.Entity;
using CourseOn.Domain.Interfaces;
using CourseOn.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseOn.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity GetById(int id)
        {
            var query = Context.Set<TEntity>().Where(entity => entity.Id == id);

            if (query is not null)
                return query.FirstOrDefault();

            return null;
        }

        //public void Add(TEntity entity)
        //{
        //    Context.Set<TEntity>().Add(entity);
        //}
    }
}

using CourseOn.Domain.Entity;
using CourseOn.Domain.Interfaces;
using CourseOn.Infrastructure.BaseContext;

namespace CourseOn.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entitye
    {
        protected CourseOnContext Context;

        public BaseRepository(CourseOnContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity GetById(int id)
        {
            var entities = Context.Set<TEntity>().Where(entity => entity.Id == id);

            if (entities.Any())
                return entities.FirstOrDefault();

            return new List<TEntity>().First();
        }
        
        public List<TEntity> GetAll()
        {
            var entities = Context.Set<TEntity>().ToList();

            if (entities.Any())
                return entities;

            return new List<TEntity>();
        }
    }
}

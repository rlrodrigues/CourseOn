namespace CourseOn.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        TEntity GetById(int id); 
    }
}

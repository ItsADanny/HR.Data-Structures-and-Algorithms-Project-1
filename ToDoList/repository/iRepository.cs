public interface IRepository<T> where T : class
{
    //CRUD
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T[] Read();
}
namespace CRUD.DAL.Repository;

public interface IRepository<T> : IDisposable
    where T : class
{
    /// <summary>
    /// Return all T - items form DbContext
    /// </summary>
    /// <returns><c>IEnumerable</c> collection</returns>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Insert new T-item in database
    /// </summary>
    /// <param name="item">Item for inserting</param>
    void Add(T item);

    /// <summary>
    /// Insert range of new T-item in databese
    /// </summary>
    /// <param name="items">Range of inserting items</param>
    void AddRange(params T[] items);

    /// <summary>
    /// Update contained T-item in database
    /// </summary>
    /// <param name="item">Item for updating</param>
    void Update(T item);

    /// <summary>
    /// Delete contained T-item form database
    /// </summary>
    /// <param name="item">Item for removing</param>
    void Delete(T item);

    /// <summary>
    /// Return all T-items form DbContext by async
    /// </summary>
    /// <returns><c>IEnumerable</c> collection</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Insert new T-item in database by async
    /// </summary>
    /// <param name="item">Item for inserting</param>
    /// <returns>Void result by default</returns>
    Task AddAsync(T item);

    /// <summary>
    /// Insert new T-item in database by async
    /// </summary>
    /// <param name="items">Range of inserting items</param>
    /// <returns>Void result by default</returns>
    Task AddRangeAsync(params T[] items);
}

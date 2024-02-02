namespace SimpleApi.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        bool Delete(int id);
        void Insert(in T sender);
        void Update(in T sender);
        int Save();
    }
}

using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repository
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public void Create(T model) => _connection.Insert(model);

        public List<T> Read() => _connection.GetAll<T>().ToList();

        public T Read(int id) => _connection.Get<T>(id);

        public void Update(T model) => _connection.Update(model);

        public void Delete(T model) => _connection.Delete(model);

        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}
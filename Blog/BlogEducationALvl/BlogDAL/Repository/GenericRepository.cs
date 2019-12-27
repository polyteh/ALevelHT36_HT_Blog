using NPoco;
using NPoco.Linq;
using System;
using System.Collections.Generic;

namespace BlogDAL.Repository
{
    public interface IGenericRepository<T>  where T: class
    {
        void CreateBulk(IEnumerable<T> items);
        int Create(T item);
        T FindById(int id);
        T FindById(string id);
        IList<T> Get();
        void Remove(T item);
        void Update(T item);
        void Dispose();
        List<T> GetDataWithQuery(string query, params object[] args);
        List<T> GetDataWithQuery(Sql sql);
        List<T> GetProperty<T>(string query, params object[] args);
        Page<T> GetDataByPage(long page, long itemPerPage, Sql sql);
    }
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly IDatabase _db;
        public GenericRepository()
        {
            _db = new Database("DBBLOG");
        }

        public int Create(T item)
        {
            throw new NotImplementedException();
        }

        public void CreateBulk(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            return _db.SingleById<T>(id);
        }

        public T FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<T> Get()
        {
            return _db.Query<T>().ToList();
        }

        public Page<T> GetDataByPage(long page, long itemPerPage, Sql sql)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataWithQuery(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataWithQuery(Sql sql)
        {
            throw new NotImplementedException();
        }

        public List<T1> GetProperty<T1>(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}

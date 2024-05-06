using MauiCustoViagem.Models;
using SQLite;

namespace MauiCustoViagem.Helpers
{
    public class SQLiteDatabaseHelperPedagio
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelperPedagio(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Pedagio>().Wait();
        }

        public Task<int> Insert(Pedagio p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Pedagio>> Update(Pedagio p)
        {
            string sql = "UPDATE Pedagio SET Local=?, Valor=?, IdViagem=? WHERE Id=?";
            return _conn.QueryAsync<Pedagio>(sql, p.Local, p.Valor, p.IdViagem, p.Id);
        }

        public Task<List<Pedagio>> GetAll()
        {
            return _conn.Table<Pedagio>().ToListAsync();
        }

        public Task Delete(int id)
        {
            return _conn.Table<Pedagio>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Pedagio>> Search(string q)
        {
            string sql = "SELECT * FROM Pedagio WHERE Local LIKE '%" + q + "%'";
            return _conn.QueryAsync<Pedagio>(sql);
        }
    }
}

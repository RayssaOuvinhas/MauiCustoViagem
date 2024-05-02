using MauiCustoViagem.Models;
using SQLite;

namespace MauiCustoViagem.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Viagem>().Wait();
        }

        public Task<int> Insert(Viagem p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Viagem>> Update(Viagem p)
        {
            string sql = "UPDATE Viagem SET Origem=? Destino=?, Distancia=?, Rendimento=?, Preco_Comb=? WHERE id=?";
            return _conn.QueryAsync<Viagem>(sql, p.Origem, p.Destino, p.Distancia, p.Rendimento, p.Preco, p.Pedagio, p.Id);
        }

        public Task<List<Viagem>> GetAll()
        {
            return _conn.Table<Viagem>().ToListAsync();
        }

        public Task Delete(int id)
        {
            return _conn.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Viagem>> Search(string q)
        {
            string sql = "SELECT * FROM Viagem WHERE Origem LIKE '%" + q + "%'";
            return _conn.QueryAsync<Viagem>(sql);
        }
    }
}

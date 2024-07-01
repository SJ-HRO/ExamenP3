using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExamenP3.Services
{
    public class DatabaseService
    {
        private readonly
            SQLiteAsyncConnection _database;
        
        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "chucknorris.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Joke>().Wait();
        }

        public Task<List<Joke>>
            GetJokesAsync() => _database.Table<Joke>().ToListAsync();

        public Task<int>
            SaveJokeAsync(Joke joke) => _database.InsertAsync(joke);

        public Task<int>
            UpdateJokeAsync(Joke joke) => _database.InsertAsync(joke);

        public Task<int>
            DeleteJokeAsync(Joke joke) => _database.InsertAsync(joke);
    }
}

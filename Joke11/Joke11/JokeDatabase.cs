using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke11
{
    public class JokeDatabase
    {
       private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

       public static SQLiteAsyncConnection Database => lazyInitializer.Value;
       public static bool initialized = false;

        public JokeDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name != nameof(Joke)))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Joke)).ConfigureAwait(false);
                    initialized = true;
                }
            }

        }
        public Task<List<Joke>> GetJokesAsync()
        {
            return Database.Table<Joke>().ToListAsync();
        }

        public Task<int> SaveJokeAsync(Joke Joke)
        {
            return Database.InsertAsync(Joke);
        }

        //...
    }
}
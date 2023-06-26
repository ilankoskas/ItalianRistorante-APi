using WebApplicationAPi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApplicationAPi.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Plats> _PlatsCollection;
        
        public BooksService(
            
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)

        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);

            _PlatsCollection = mongoDatabase.GetCollection<Plats>(bookStoreDatabaseSettings.Value.BooksCollectionName);
            



        }
        public async Task<List<Plats>>GetAsync()=>
        await _PlatsCollection.Find(_ => true).ToListAsync();

        public async Task<Plats?>GetPlatsAsync(String id) =>
        await _PlatsCollection.Find(x => x.Id==id).FirstOrDefaultAsync();

        public async Task CreateAsync(Plats newPlats)=>
        await _PlatsCollection.InsertOneAsync(newPlats);

        public async Task UpdateAsync(String id, Plats UpdatePlats) =>
        await _PlatsCollection.ReplaceOneAsync(x => x.Id == id, UpdatePlats);

        public async Task RemoveAsync(String id) =>
        await _PlatsCollection.DeleteOneAsync(x => x.Id==id);

    }
}

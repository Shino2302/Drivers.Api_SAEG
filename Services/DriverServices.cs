using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using Drivers.Api.Models;
using Drivers.Api.Configurations;
using Microsoft.Extensions.Options;

namespace Drivers.Api.Services
{
    public class DriverServices
    {
        private readonly IMongoCollection<Drivers.Api.Models.Driver> _driverCollection;
        
        public DriverServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDB =
            mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
                _driverCollection =
                    mongoDB.GetCollection<Drivers.Api.Models.Driver>(databaseSettings.Value.CollectionName);
        }
        public async Task<List<Drivers.Api.Models.Driver>> GetAsync() =>
            await _driverCollection.Find(_ => true).ToListAsync();
    }
}
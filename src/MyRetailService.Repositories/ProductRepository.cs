using System;
using System.Linq;

using MongoDB.Bson;
using MongoDB.Driver;

using MyRetailService.Interfaces.Repositories;
using MyRetailService.ServiceModel.Types;

namespace MyRetailService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Fields

        private readonly IMongoCollection<BsonDocument> _collection;

        private IMongoClient _mongoClient;

        #endregion

        #region Constructor
        public ProductRepository(IMongoClient mongoClient, string databaseName, string collectionName)
        {
            _mongoClient = mongoClient;

            var database = _mongoClient.GetDatabase(databaseName);

            _collection = database.GetCollection<BsonDocument>(collectionName);
        }

        #endregion

        #region Public Methods

        public ProductPrice GetProductCurrentPrice(Int64 requestId)
        {
            var getFilter = Builders<BsonDocument>.Filter.Eq("ProductId", requestId);

            var test = _collection.Find(getFilter);
            var collection = _collection.Find(getFilter).First();

            return collection.IsBsonUndefined ||collection.IsBsonNull
                ? null
                : new ProductPrice()
                {
                    CurrencyCode = collection["CurrencyCode"].ToString(),
                    Value = collection["Value"].ToDecimal()
                };

        }

        public void UpdateProductCurrentPrice(Int64 requestId, decimal updatedPrice)
        {
            var getFilter = Builders<BsonDocument>.Filter.Eq("ProductId", requestId);

            var updateParameter = Builders<BsonDocument>.Update.Set("Price", updatedPrice);

             _collection.UpdateOne(getFilter, updateParameter);
        }

        #endregion
    }
}

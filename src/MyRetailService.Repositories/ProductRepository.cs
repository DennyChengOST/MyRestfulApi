using MongoDB.Bson;
using MongoDB.Driver;
using MyRetailService.Interfaces.Repositories;
using MyRetailService.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public object UpdateProductCurrentPrice(string requestId, decimal updatedPrice)
        {
            var getFilter = Builders<BsonDocument>.Filter.Eq("ProductId", requestId);

            var updateParameter = Builders<BsonDocument>.Update.Set("Price", updatedPrice);

            return _collection.UpdateOne(getFilter, updateParameter);
            //Do I need to potentially account for user wanting to change Currency Code?
            //just return 200 for success
        }

        #endregion
    }
}

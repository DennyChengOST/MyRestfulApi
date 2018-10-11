using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using AutoFixture;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;

using MyRetailService.Repositories;

namespace MyRetailService.Tests.UnitTests.Repositories
{
    [TestClass]
   public class ProductRepositoryShould
    {
        #region Fields

        private Fixture _fixture;

        private Mock<IMongoClient> _mockMongoClient;

        private Mock<IMongoDatabase> _mockMongoDatabase;

        private Mock<IMongoCollection<BsonDocument>> _mockMongoCollection;

        private string _mockDatabaseName = "mockDatabase";

        private string _mockCollectionName = "mockCollection";

        private ProductRepository _productRepository;

        #endregion

        #region Setup

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();
            _mockMongoClient = new Mock<IMongoClient>();
            _mockMongoDatabase = new Mock<IMongoDatabase>();
            _mockMongoCollection = new Mock<IMongoCollection<BsonDocument>>();

            _mockMongoClient.Setup(client => client.GetDatabase(It.IsAny<string>(),null))
                .Returns(_mockMongoDatabase.Object);
            _mockMongoDatabase.Setup(database => database.GetCollection<BsonDocument>(It.IsAny<string>(),null))
                .Returns(_mockMongoCollection.Object);

            _productRepository = new ProductRepository(_mockMongoClient.Object, _mockDatabaseName, _mockCollectionName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _fixture = null;
            _mockMongoClient = null;
            _productRepository = null;
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void GetProductCurrentPrice_ProductIdExists_ReturnsCollection()
        {
            //Arrange
            var requestId = _fixture.Create<Int64>();
            var collection = new BsonDocument("firstName","peter");

            //TODO: figure out how to construct a IFindFluent response :( 
            //var collectionFindResponse = IFindFluent<collecction>;
            //_mockMongoCollection.Setup(collectionTable => collectionTable.Find(It.IsAny<FilterDefinition<BsonDocument>>(), null))
            //    .Returns(collection);

            //Act
            //var result = _productRepository.GetProductCurrentPrice(requestId);

            //Assert
        }

        [TestMethod]
        public void GetProductCurrentPrice_ProductIdNotFound_ReturnsFalse()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void UpdateProductCurrentPrice_ValidRequest_CallsCollection()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void PopulateDataBasewithProduct_RequestMade_CallsCollection()
        {
            //Arrange

            //Act

            //Assert

        }

        #endregion
    }
}

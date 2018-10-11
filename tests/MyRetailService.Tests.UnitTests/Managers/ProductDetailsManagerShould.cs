using Microsoft.VisualStudio.TestTools.UnitTesting;

using AutoFixture;
using Moq;
using Shouldly;

using MyRetailService.DataModels;
using MyRetailService.Interfaces.Repositories;
using MyRetailService.Managers;
using MyRetailService.ServiceModel.Types;

namespace MyRetailService.Tests.UnitTests.Managers
{
    [TestClass]
    public class ProductDetailsManagerShould
    {
        #region Fields

        private Fixture _fixture;

        private Mock<IProductRepository> _mockProductPricesRepository;

        private Mock<IRedSkyRepository> _mockRedSkyRepository;

        private ProductDetailsManager _productDetailsManager;

        #endregion

        #region Setup

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();
            _mockProductPricesRepository = new Mock<IProductRepository>();
            _mockRedSkyRepository = new Mock<IRedSkyRepository>();
            _productDetailsManager = new ProductDetailsManager(_mockProductPricesRepository.Object, _mockRedSkyRepository.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _fixture = null;
            _mockProductPricesRepository = null;
            _mockRedSkyRepository = null;
            _productDetailsManager = null;
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void ReadByProductId_ProductDataExists_CallsRepositoryReturnsPopulatedModel()
        {
            //Arrange
            var productDetailsModel = _fixture.Create<ProductDetailsModel>();
            var productId = productDetailsModel.Id;
            var productName = _fixture.Create<string>();
            var productPrice = _fixture.Create<ProductPrice>();

            _mockRedSkyRepository.Setup(repository => repository.GetProductName(productId))
                .Returns(productName);
            _mockProductPricesRepository.Setup(repository => repository.GetProductCurrentPrice(productId))
                .Returns(productPrice);

            //Act
            var result = _productDetailsManager.ReadByProductId(productDetailsModel);

            //Assert
            result.Id.ShouldBe(productId);
            result.Name.ShouldBe(productName);
            result.CurrentPrice.ShouldBeSameAs(productPrice);
            _mockRedSkyRepository.Verify(repository => repository.GetProductName(productId), Times.Once);
            _mockProductPricesRepository.Verify(repository => repository.GetProductCurrentPrice(productId), Times.Once);
        }

        [TestMethod]
        public void ReadByProductId_ProductNameDoesntExist_ReturnsNull()
        {
            //Arrange
            var productDetailsModel = _fixture.Create<ProductDetailsModel>();
            var productId = productDetailsModel.Id;
            var productName = "";
            var productPrice = _fixture.Create<ProductPrice>();

            _mockRedSkyRepository.Setup(repository => repository.GetProductName(productId))
                .Returns(productName);
            _mockProductPricesRepository.Setup(repository => repository.GetProductCurrentPrice(productId))
                .Returns(productPrice);

            //Act
            var result = _productDetailsManager.ReadByProductId(productDetailsModel);

            //Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void UpdateProductPrice_AllScenarios_CallsRepository()
        {
            //Arrange
            var productUpdateModel = _fixture.Create<ProductUpdateModel>();

            //Act
            _productDetailsManager.UpdateProductPrice(productUpdateModel);

            //Assert
            _mockProductPricesRepository.Verify(repository => repository.UpdateProductCurrentPrice(productUpdateModel.Id, productUpdateModel.Value), Times.Once);
        }

        #endregion
    }
}

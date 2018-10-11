using Microsoft.VisualStudio.TestTools.UnitTesting;

using AutoFixture;
using AutoMapper;
using Moq;
using Shouldly;

using MyRetailService.DataModels;
using MyRetailService.Interfaces.Managers;
using MyRetailService.ServiceDefinition;
using MyRetailService.ServiceModel.Messages;

namespace MyRetailService.Tests.UnitTests.Services
{
    [TestClass]
    public class ProductDetailsServiceShould
    {
        #region Fields

        private Fixture _fixture;

        private Mock<IMapper> _mockMapper;

        private Mock<IProductDetailsManager> _mockProductDetailsManager;

        private ProductDetailsService _productDetailsService;

        #endregion

        #region Setup

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();
            _mockMapper = new Mock<IMapper>();
            _mockProductDetailsManager = new Mock<IProductDetailsManager>();
            _productDetailsService = new ProductDetailsService(_mockProductDetailsManager.Object, _mockMapper.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _fixture = null;
            _mockMapper = null;
            _mockProductDetailsManager = null;
            _productDetailsService = null;
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Get_AllScenarios_CallsManager()
        {
            //Arrange
            var getProductRequest = _fixture.Create<GetProductRequest>();
            var readProductIdRequest = _fixture.Create<ProductDetailsModel>();
            var readProductIdResponse = _fixture.Create<ProductDetailsModel>();
            var getProductResponse = _fixture.Create<GetProductResponse>();

            _mockMapper.Setup(mapper => mapper.Map<ProductDetailsModel>(getProductRequest))
                .Returns(readProductIdRequest);
            _mockProductDetailsManager.Setup(manager => manager.ReadByProductId(readProductIdRequest))
                .Returns(readProductIdResponse);
            _mockMapper.Setup(mapper => mapper.Map<GetProductResponse>(readProductIdResponse))
                .Returns(getProductResponse);

            //Act
            var response = _productDetailsService.Get(getProductRequest);

            //Assert
            response.Id.ShouldBe(getProductResponse.Id);
            response.Name.ShouldBe(getProductResponse.Name);
            response.CurrentPrice.ShouldBeSameAs(getProductResponse.CurrentPrice);
            _mockProductDetailsManager.Verify(manager => manager.ReadByProductId(readProductIdRequest), Times.Once);
        }

        [TestMethod]
        public void Put_AllScenarios_CallsManager()
        {
            //Arrange
            var putUpdateProductPriceRequest = _fixture.Create<PutUpdateProductPrice>();
            var updateProductRequest = _fixture.Create<ProductUpdateModel>();

            _mockMapper.Setup(mapper => mapper.Map<ProductUpdateModel>(putUpdateProductPriceRequest))
                .Returns(updateProductRequest);

            //Act
            _productDetailsService.Put(putUpdateProductPriceRequest);

            //Assert
            _mockProductDetailsManager.Verify(manager => manager.UpdateProductPrice(updateProductRequest), Times.Once);
        }

        #endregion
    }
}

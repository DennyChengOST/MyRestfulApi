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
            var getProductDetailsRequest = _fixture.Create<GetProductDetailsRequest>();
            var readProductIdRequest = _fixture.Create<ProductDetailsModel>();
            var readProductIdResponse = _fixture.Create<ProductDetailsModel>();
            var getProductDetailsResponse = _fixture.Create<GetProductDetailsResponse>();

            _mockMapper.Setup(mapper => mapper.Map<ProductDetailsModel>(getProductDetailsRequest))
                .Returns(readProductIdRequest);
            _mockProductDetailsManager.Setup(manager => manager.ReadByProductId(readProductIdRequest))
                .Returns(readProductIdResponse);
            _mockMapper.Setup(mapper => mapper.Map<GetProductDetailsResponse>(readProductIdResponse))
                .Returns(getProductDetailsResponse);

            //Act
            var response = _productDetailsService.Get(getProductDetailsRequest);

            //Assert
            response.Id.ShouldBe(getProductDetailsResponse.Id);
            response.Name.ShouldBe(getProductDetailsResponse.Name);
            response.CurrentPrice.ShouldBeSameAs(getProductDetailsResponse.CurrentPrice);
            _mockProductDetailsManager.Verify(manager => manager.ReadByProductId(readProductIdRequest), Times.Once);
        }

        #endregion
    }
}

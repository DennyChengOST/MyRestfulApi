using Microsoft.VisualStudio.TestTools.UnitTesting;

using AutoFixture;
using AutoMapper;
using Shouldly;

using MyRetailService.DataModels;
using MyRetailService.ServiceModel.Messages;

namespace MyRetailService.Tests.UnitTests
{
    [TestClass]
    public class MappingConfiguratorShould
    {
        #region Fields

        private Fixture _fixture;

        private IMapper _mapper;

        #endregion

        #region Setup

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();
            _mapper = new MappingConfigurator().CreateMaps().CreateMapper();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Map_GetProductRequestToProductDetailsModel_MapsCorrectly()
        {
            // Arrange
            var source = _fixture.Create<GetProductRequest>();

            // Act
            var target = _mapper.Map<ProductDetailsModel>(source);

            // Assert
            target.Id.ShouldBe(source.Id);
        }

        [TestMethod]
        public void Map_ProductDetailsModelToGetProductResponse_MapsCorrectly()
        {
            // Arrange
            var source = _fixture.Create<ProductDetailsModel>();

            // Act
            var target = _mapper.Map<GetProductResponse>(source);

            // Assert
            target.Id.ShouldBe(source.Id);
            target.Name.ShouldBe(source.Name);
            target.CurrentPrice.ShouldBeSameAs(source.CurrentPrice);
        }

        [TestMethod]
        public void Map_PutUpdateProductPriceToProductUpdateModel()
        {
            //Arrange
            var source = _fixture.Create<PutUpdateProductPrice>();

            //Act
            var target = _mapper.Map<ProductUpdateModel>(source);

            //Assert
            target.Id.ShouldBe(source.Id);
            target.Value.ShouldBe(source.CurrentPrice.Value);
        }

        #endregion

    }
}

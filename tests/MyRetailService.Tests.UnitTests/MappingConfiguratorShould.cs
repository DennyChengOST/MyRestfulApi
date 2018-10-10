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
        public void Map_GetProductDetailsRequestToProductDetailsModel_MapsCorrectly()
        {
            // Arrange
            var source = _fixture.Create<GetProductDetailsRequest>();

            // Act
            var target = _mapper.Map<ProductDetailsModel>(source);

            // Assert
            target.Id.ShouldBe(source.Id);
        }

        [TestMethod]
        public void Map_ProductDetailsModelToGetProductDetailsResponse_MapsCorrectly()
        {
            // Arrange
            var source = _fixture.Create<ProductDetailsModel>();

            // Act
            var target = _mapper.Map<GetProductDetailsResponse>(source);

            // Assert
            target.Id.ShouldBe(source.Id);
            target.Name.ShouldBe(source.Name);
            target.CurrentPrice.ShouldBeSameAs(source.CurrentPrice);
        }

        #endregion

    }
}


using AutoFixture;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyRetailService.Interfaces.Repositories;
using MyRetailService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.Tests.UnitTests.Managers
{
    [TestClass]
    public class ProductDetailsManagerShould
    {
        #region Fields

        private Fixture _fixture;

        private Mock<IProductPricesRepository> _mockProductPricesRepository;

        private Mock<IRedSkyRepository> _mockRedSkyRepository;

        private ProductDetailsManager _productDetailsManager;

        #endregion

        #region Setup

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();
            _mockProductPricesRepository = new Mock<IProductPricesRepository>();
            _productDetailsManager = new ProductDetailsManager(_mockProductPricesRepository.Object, _mockRedSkyRepository.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _fixture = null;
            _mockProductPricesRepository = null;
            _productDetailsManager = null;
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void ReadByProductId_ProductNameExists_CallsRepositoryReturnsPopulatedModel()
        {
            //Arrange

            //Act

            //Assert
            
        }

        [TestMethod]
        public void ReadByProductId_ProductNameDoesntExist_DoesntCallRepositoryReturnsError()
        {
            //Arrange

            //Act

            //Assert

        }

        #endregion
    }
}

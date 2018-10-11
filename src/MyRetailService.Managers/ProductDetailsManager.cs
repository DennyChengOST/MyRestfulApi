using MyRetailService.DataModels;
using MyRetailService.Interfaces.Managers;
using MyRetailService.Interfaces.Repositories;
using MyRetailService.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.Managers
{
    public class ProductDetailsManager : IProductDetailsManager
    {
        #region Fields

        private readonly IProductRepository _productPricesRepository;

        private readonly IRedSkyRepository _redSkyRepository;

        #endregion

        #region Constructors
        public ProductDetailsManager(IProductRepository productPricesRepository, IRedSkyRepository redSkyRepository)
        {
            _productPricesRepository = productPricesRepository;
            _redSkyRepository = redSkyRepository;
        }

        #endregion

        #region Public Methods

        public ProductDetailsModel ReadByProductId(ProductDetailsModel productDetailsModel)
        {
            string productName = null;
            ProductPrice productPrice = null;

            Parallel.Invoke(
                () => productName = _redSkyRepository.GetProductName(productDetailsModel.Id),
                () => productPrice = _productPricesRepository.GetProductCurrentPrice(productDetailsModel.Id)
                );
            return string.IsNullOrWhiteSpace(productName)
                ? null
                : new ProductDetailsModel
                {
                    Name = productName,
                    CurrentPrice = productPrice,
                    Id = productDetailsModel.Id
                };   
        }

        #endregion
    }
}

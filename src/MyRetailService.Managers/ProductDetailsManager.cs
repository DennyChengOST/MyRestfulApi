using MyRetailService.DataModels;
using MyRetailService.Interfaces.Managers;
using MyRetailService.Interfaces.Repositories;
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

        private readonly IProductPricesRepository _productPricesRepository;

        private readonly IRedSkyRepository _redSkyRepository;

        #endregion

        #region Constructors
        public ProductDetailsManager(IProductPricesRepository productPricesRepository, IRedSkyRepository redSkyRepository)
        {
            _productPricesRepository = productPricesRepository;
            _redSkyRepository = redSkyRepository;
        }

        #endregion

        #region Public Methods

        public ProductDetailsModel ReadByProductId(ProductDetailsModel productDetailsModel)
        {
            //Call out to HTTP GET for product name
            var productName = _redSkyRepository.GetProductName(productDetailsModel.Id);
            //Make sure productName exists and if so get the product price
            if (!string.IsNullOrEmpty(productName))

            {
                //nested conditional to check if productPrice is empty? or over doing it :|?
                //MongoCall
                var productPrice = _productPricesRepository.GetProductCurrentPrice(productDetailsModel.Id);
                productDetailsModel.Name = productName;
                productDetailsModel.CurrentPrice = productPrice;
                return productDetailsModel;
            }
            else
            {
                //Better error message? or is this check even needed? D: 
                productDetailsModel.Name = "Product name is not found";
                return productDetailsModel;
            }
        }

        #endregion
    }
}

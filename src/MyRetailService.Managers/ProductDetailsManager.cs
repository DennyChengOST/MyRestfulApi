using System.Threading.Tasks;

using MyRetailService.DataModels;
using MyRetailService.Interfaces.Managers;
using MyRetailService.Interfaces.Repositories;
using MyRetailService.ServiceModel.Types;

namespace MyRetailService.Managers
{
    public class ProductDetailsManager : IProductDetailsManager
    {
        #region Fields

        private readonly IProductRepository _productRepository;

        private readonly IRedSkyRepository _redSkyRepository;

        #endregion

        #region Constructors
        public ProductDetailsManager(IProductRepository productRepository, IRedSkyRepository redSkyRepository)
        {
            _productRepository = productRepository;
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
                () => productPrice = _productRepository.GetProductCurrentPrice(productDetailsModel.Id)
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

        public void UpdateProductPrice(ProductUpdateModel productUpdateModel)
        {
            _productRepository.UpdateProductCurrentPrice(productUpdateModel.Id, productUpdateModel.Value);
        }

        public void PopulateDatabase()
        {
            _productRepository.PopulateDatabaseWithProduct();
        }

        #endregion
    }
}

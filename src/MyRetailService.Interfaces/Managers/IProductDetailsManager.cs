using MyRetailService.DataModels;

namespace MyRetailService.Interfaces.Managers
{
    public interface IProductDetailsManager
    {
        ProductDetailsModel ReadByProductId(ProductDetailsModel productDetailsModel);

        void UpdateProductPrice(ProductUpdateModel productUpdateModel);

        void PopulateDatabase();
    }
}

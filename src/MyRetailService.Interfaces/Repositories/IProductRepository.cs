using System;

using MyRetailService.ServiceModel.Types;

namespace MyRetailService.Interfaces.Repositories
{
    public interface IProductRepository
    {
        ProductPrice GetProductCurrentPrice(Int64 requestId);

        void UpdateProductCurrentPrice(Int64 requestId, decimal updatedPrice);
    }
}

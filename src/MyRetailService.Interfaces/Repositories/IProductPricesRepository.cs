using MyRetailService.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.Interfaces.Repositories
{
    public interface IProductPricesRepository
    {
        ProductPrice GetProductCurrentPrice(Int64 requestId);

        object UpdateProductCurrentPrice(string requestId, decimal updatedPrice);
    }
}

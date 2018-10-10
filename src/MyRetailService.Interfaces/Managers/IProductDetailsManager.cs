using MyRetailService.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.Interfaces.Managers
{
    public interface IProductDetailsManager
    {
        ProductDetailsModel ReadByProductId(ProductDetailsModel productDetailsModel);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.DataModels
{
    public class ProductUpdateModel
    {
        //Bad idea to make this generic to future proof needing to update anything on a item not just
        //bad idea to flatten the ProductPrice layer and the item?
        //price?
        public Int64 Id { get; set; }

        public decimal Value { get; set; }
    }
}

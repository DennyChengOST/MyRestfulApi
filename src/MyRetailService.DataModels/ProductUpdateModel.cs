using System;

namespace MyRetailService.DataModels
{
    public class ProductUpdateModel
    {
        //Flatten out the obj from Product and ProductPrice level through automapper
        //could easily add other properties we potentially want to edit
        public Int64 Id { get; set; }

        public decimal Value { get; set; }

    }
}

using AutoMapper;
using MyRetailService.DataModels;
using MyRetailService.Interfaces.Managers;
using MyRetailService.ServiceModel.Messages;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.ServiceDefinition
{
    public class ProductDetailsService : Service
    {
        #region Fields

        private readonly IProductDetailsManager _productDetailsManager;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ProductDetailsService(IProductDetailsManager productDetailsManager, IMapper mapper)
        {
            _productDetailsManager = productDetailsManager;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public GetProductDetailsResponse Get(GetProductDetailsRequest request)
        {
            var readByProductIdRequest = _mapper.Map<ProductDetailsModel>(request);
            var readByProductIdResponse = _productDetailsManager.ReadByProductId(readByProductIdRequest);
            //manager not found or null* throw error* handle this error*

            var getProductDetailsResponse = _mapper.Map<GetProductDetailsResponse>(readByProductIdResponse);
            return getProductDetailsResponse;
        }

        //public PutUpdateProductPriceResponse Put(PutUpdateProductPrice request)
        //{
        //    var updateProductRequest = _mapper.Map<ProductUpdateModel>(request);
        //    //manager call
        //    //Potentially return product reponse should I also include the updated obj
        //}

        #endregion
    }
}

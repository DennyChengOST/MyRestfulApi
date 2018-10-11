using ServiceStack;

using AutoMapper;

using MyRetailService.DataModels;
using MyRetailService.Interfaces.Managers;
using MyRetailService.ServiceModel.Messages;

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

        public GetProductResponse Get(GetProductRequest request)
        {
            var readByProductIdRequest = _mapper.Map<ProductDetailsModel>(request);
            var readByProductIdResponse = _productDetailsManager.ReadByProductId(readByProductIdRequest);

            var getProductResponse = _mapper.Map<GetProductResponse>(readByProductIdResponse);
            return getProductResponse;
        }

        public PutUpdateProductPriceResponse Put(PutUpdateProductPrice request)
        {
            //TODO: Request validator to make properties required
            var updateProductRequest = _mapper.Map<ProductUpdateModel>(request);

            _productDetailsManager.UpdateProductPrice(updateProductRequest);

            return new PutUpdateProductPriceResponse();
        }

        public PostPopulateDatabaseResponse Post(PostPopulateDatabase request)
        {
            _productDetailsManager.PopulateDatabase();

            return new PostPopulateDatabaseResponse();
        }
        #endregion
    }
}

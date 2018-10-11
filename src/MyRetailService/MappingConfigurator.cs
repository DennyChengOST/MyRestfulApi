using AutoMapper;
using MyRetailService.DataModels;
using MyRetailService.ServiceModel.Messages;

namespace MyRetailService
{
    public class MappingConfigurator
    {
        #region IMappingConfigurator Implementation

        public MapperConfiguration CreateMaps()
        {
            var config = new MapperConfiguration(mapperConfiguration =>
            {
                MapServiceModelToDataModel(mapperConfiguration);
                MapDataModelToServiceModel(mapperConfiguration);
            });

            return config;
        }

        #endregion

        #region Private Methods

        private static void MapServiceModelToDataModel(IProfileExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<GetProductRequest, ProductDetailsModel>();
            mapperConfiguration.CreateMap<PutUpdateProductPrice, ProductUpdateModel>()
                .ForMember(target => target.Value, opt => opt.MapFrom(source => source.CurrentPrice.Value));

        }

        private static void MapDataModelToServiceModel(IProfileExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<ProductDetailsModel, GetProductResponse>();

        }

        #endregion
    }
}

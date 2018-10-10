using AutoMapper;
using MyRetailService.DataModels;
using MyRetailService.ServiceModel.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRetailService
{
    public static class MappingConfigurator
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(mapperConfiguration =>
            {
                MapServiceModelToDataModel(mapperConfiguration);
                MapDataModelToServiceModel(mapperConfiguration);
            });
            return config.CreateMapper();

        }

        private static void MapServiceModelToDataModel(IProfileExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<GetProductDetailsRequest, ProductDetailsModel>();

        }

        private static void MapDataModelToServiceModel(IProfileExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<ProductDetailsModel, GetProductDetailsResponse>();

        }
    }
}

using Funq;
using ServiceStack.Validation;
using MyRetailService.Validation;
using MyRetailService.Repositories;
using MyRetailService.Interfaces.Repositories;
using MyRetailService.Interfaces.Managers;
using MyRetailService.Managers;

namespace MyRetailService
{
    public static class ContainerManager
    {
        public static void Register(Container container)
        {
            // add service validation
            container.RegisterValidators(ReuseScope.Container, typeof(ValidationInfo).Assembly);

            // Mapper
            var mappingConfigurator = new MappingConfigurator();
            var mappingConfiguration = mappingConfigurator.CreateMaps();
            container.Register(c => mappingConfiguration.CreateMapper());

            // Repositories
            container.RegisterAs<ProductPricesRepository, IProductPricesRepository>();
            container.RegisterAs<RedskyRepository, IRedSkyRepository>();

            // Managers
            container.RegisterAs<ProductDetailsManager, IProductDetailsManager>();
        }

    }
}

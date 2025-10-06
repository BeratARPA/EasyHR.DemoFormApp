using EasyHR.DemoFormApp.Business.Abstract;
using EasyHR.DemoFormApp.Business.Concrete;
using EasyHR.DemoFormApp.Business.Mapping;
using EasyHR.DemoFormApp.Business.Validation;
using EasyHR.DemoFormApp.DataAccess;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EasyHR.DemoFormApp.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddDataAccessLayer();
            services.AddScoped<IFormService, FormService>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddValidatorsFromAssembly(typeof(FormCreateDtoValidator).Assembly);

            return services;
        }
    }
}

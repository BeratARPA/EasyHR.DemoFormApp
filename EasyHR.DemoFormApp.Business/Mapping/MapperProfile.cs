using AutoMapper;
using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.Entities.Entities;

namespace EasyHR.DemoFormApp.Business.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<FormCreateDto, Form>();            
            CreateMap<Form, FormListDto>();
            CreateMap<Form, FormDetailDto>();
        }      
    }
}

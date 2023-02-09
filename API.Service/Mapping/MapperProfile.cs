using API.Domain.Entity;
using AutoMapper;
using SharedModels.Models;

namespace API.Service.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SubElement, SubElementViewModel>();
            CreateMap<SubElementViewModel, SubElement>();

            CreateMap<Window, WindowViewModel>();
            CreateMap<WindowViewModel, Window>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();
        }
    }
}

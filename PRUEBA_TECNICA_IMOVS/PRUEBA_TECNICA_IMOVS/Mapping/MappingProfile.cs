using AutoMapper;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Api.Models.Entities;


namespace PRUEBA_TECNICA_IMOVS.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();


            CreateMap<Ticket, TicketListItemDto>();
            CreateMap<Ticket, TicketDetailDto>();


            CreateMap<TicketLine, TicketLineDto>()
            .ForMember(d => d.ProductSku, m => m.MapFrom(s => s.Product.Sku))
            .ForMember(d => d.ProductName, m => m.MapFrom(s => s.Product.Name));


            CreateMap<Payment, PaymentDto>();
        }
    }
}
using AutoMapper;
using CloudForAllTest.API.Models;
using CloudForAllTest.Domain;
using CloudForAllTest.Domain.Models;
using CloudForAllTest.Domain.Models.DTOs;

namespace CloudForAllTest.API.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserAPIModel, User>();
            CreateMap<PreventaApiModelCreate, Preventa>();
            CreateMap<PreventaApiModel, Preventa>();
            CreateMap<Preventa, PreventaApiModel>();
            CreateMap<ProductoApiModelCreate, Producto>();
            CreateMap<ProductoApiModel, Producto>();
            CreateMap<Producto, ProductoApiModel>();
            CreateMap<FacturaApiModel, FacturaDTO>();
            CreateMap<Factura, FacturaApiModelRead>()
                .ForMember(dest =>
                    dest.PreventaId,
                    source => source.MapFrom(src => src.Preventa.PreventaId)
                )
                .ForMember(dest =>
                    dest.NomProducto,
                    source => source.MapFrom(src => src.Producto.NomProducto)
                )
                .ForMember(dest =>
                    dest.ValorProducto,
                    source => source.MapFrom(src => src.Producto.ValorUnitario)
                );
            CreateMap<Factura, FacturaReponseModel>()
                .ForMember(dest =>
                    dest.Despacho,
                    source => source.MapFrom(src => src.Preventa.LugarDespacho)
                )
                .ForMember(dest =>
                    dest.ValorFactura,
                    source => source.MapFrom(src => src.Total)
                );
        }
    }
}

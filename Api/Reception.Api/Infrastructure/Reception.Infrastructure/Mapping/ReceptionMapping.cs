using AutoMapper;
using Reception.Contracts.Common;
using Reception.Contracts.Reception;
using Reception.Domain.Entities;

namespace Reception.Infrastructure
{
    public class ReceptionMapping : Profile
    {
        public ReceptionMapping()
        {
            CreateMap<Order, OrderRegistryItem>();
            CreateMap<Client, ClientDto>()
                .ForMember(d => d.Type, o => o.MapFrom(s => s.ClientType));

            CreateMap<OrderStatus, EnumType>()
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Name));

            CreateMap<ClientType, EnumType>()
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Name));

            CreateMap<Equipment, EquipmentDto>();
            CreateMap<PartOrderItem, PartOrderItemDto>();
        }
    }
}

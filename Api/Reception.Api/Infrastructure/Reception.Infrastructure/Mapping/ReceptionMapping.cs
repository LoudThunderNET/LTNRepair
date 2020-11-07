using AutoMapper;
using Domain;
using Domain.Entities;
using Reception.Handlers.Order;
using System;

namespace Reception.Infrastructure
{
    public class ReceptionMapping : Profile
    {
        public ReceptionMapping()
        {
            CreateMap<Order, OrderRegistryItem>();
        }
    }
}

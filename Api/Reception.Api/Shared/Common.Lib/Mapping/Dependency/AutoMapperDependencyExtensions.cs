using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Common.Lib.AutoMapper.Dependency
{
    public static class AutoMapperDependencyExtensions
    {
        private readonly static ICollection<Type> _profiles = new List<Type>();
        public static IServiceCollection AddMapping(this IServiceCollection services, Action<TypeMapperRegistration> typeMapperConfiguration )
        {
            if (typeMapperConfiguration == null)
            {
                throw new ArgumentNullException("Не задан профайлер маппинга");
            }

            services.AddAutoMapper(cfg =>
            {
                foreach (var profileType in _profiles)
                {
                    cfg.AddProfile(profileType);
                }
            });

            return services;
        }

        public static TypeMapperRegistration AddProfile<TProfile>(this TypeMapperRegistration typeMapperRegistration) where TProfile : Profile
        {
            _profiles.Add(typeof(TProfile));

            return typeMapperRegistration;
        }
    }

    public class TypeMapperRegistration
    { 

    }
}

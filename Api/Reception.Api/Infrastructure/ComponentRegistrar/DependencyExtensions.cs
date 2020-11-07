using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using MediatR;

namespace ComponentRegistrar
{
    public static class DependencyExtensions
    {
        public static void AddMediatr(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);

        }
    }
}

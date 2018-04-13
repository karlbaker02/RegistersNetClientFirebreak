using GovukRegistersApiClientNet.Implementation.Factories;
using GovukRegistersApiClientNet.Implementation.Helpers;
using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRegistersApiClient(this IServiceCollection services)
        {
            services.AddSingleton<IDataStore, InMemoryDataStore>()
                .AddSingleton<IRsfDownloadService, RsfDownloadService>()
                .AddSingleton<IRsfUpdateService, RsfUpdateService>()
                .AddSingleton<ISha256Service, Sha256Service>()
                .AddSingleton<IRegisterClientFactory, RegisterClientFactory>()
                .AddSingleton<IItemFactory, ItemFactory>()
                .AddSingleton<JsonConverter, DashToUnderscoreJsonConverter>();

            return services;
        }
    }
}

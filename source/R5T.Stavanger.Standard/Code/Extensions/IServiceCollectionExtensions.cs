using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Stavanger.Default;
using R5T.Stavanger.NetStandard;


namespace R5T.Stavanger.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IShortcutOperator"/> service.
        /// </summary>
        public static IServiceCollection AddShortcutOperator(this IServiceCollection services)
        {
            services.AddNetStandardShortcutOperator(
                services.AddDefaultShortcutPathConventionsAction())
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IShortcutOperator"/> service.
        /// </summary>
        public static ServiceAction<IShortcutOperator> AddShortcutOperatorAction(this IServiceCollection services,
            ServiceAction<IShortcutPathConventions> addShortcutPathConventions)
        {
            var serviceAction = new ServiceAction<IShortcutOperator>(() => services.AddShortcutOperator());
            return serviceAction;
        }
    }
}

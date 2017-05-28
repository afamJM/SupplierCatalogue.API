// <copyright file="HealthCheckService.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Loader;
    using Microsoft.DotNet.InternalAbstractions;
    using Microsoft.Extensions.DependencyModel;
    using SupplierCatalogue.API.Infrastructure;
    using SupplierCatalogue.Models;

    /// <summary>
    /// A service to provide the system health check
    /// </summary>
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IEnumerable<TypeInfo> healthConcerns;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The applications service provider.</param>
        public HealthCheckService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            var rootAssembly = this.GetType().GetTypeInfo().Assembly;
            this.healthConcerns = this.GetHealthConcernsFromAssembly(rootAssembly);
            foreach (var assemblyName in rootAssembly.GetReferencedAssemblies())
            {
                this.healthConcerns.Concat(this.GetHealthConcernsFromAssembly(AssemblyLoadContext.Default.LoadFromAssemblyName(assemblyName)));
            }
        }

        /// <inheritdoc/>
        public HealthCheckResults CheckHealth()
        {
            return new HealthCheckResults(
                "Hitched Supplier Catalogue",
                this.healthConcerns
                    .Select(x => this.GetHealthCheckForType(x))
                    .Where(x => x != null));
        }

        /// <summary>
        /// Gets the health check for a type that implements <see cref="IHealthConcern"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The health check results</returns>
        /// <exception cref="ArgumentException">type must impelemnt IHealthConcern - type</exception>
        /// <remarks>
        /// For this to work, the type must be a class that implements IHealthConcern and must be available
        /// via dependancy injection (either directly or via one of it's interfaces) or, as a last resort,
        /// have a parameterless constructor.
        /// </remarks>
        private HealthCheckResult GetHealthCheckForType(TypeInfo type)
        {
            if (!type.IsClass || !type.ImplementedInterfaces.Contains(typeof(IHealthConcern)))
            {
                throw new ArgumentException("must be a class that impelements IHealthConcern", "type");
            }

            IHealthConcern result = null;
            result = (IHealthConcern)this.serviceProvider.GetService(type.AsType());
            if (result == null)
            {
                foreach (var interfaceType in type.ImplementedInterfaces)
                {
                    var candidateType = this.serviceProvider.GetService(interfaceType);
                    if (candidateType != null && candidateType.GetType() == type.AsType())
                    {
                        result = (IHealthConcern)candidateType;
                    }
                }
            }

            return result?.CheckHealth();
        }

        /// <summary>
        /// Gets the health concerns from an assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The health concerns</returns>
        private IEnumerable<TypeInfo> GetHealthConcernsFromAssembly(Assembly assembly)
        {
            return assembly.DefinedTypes
                .Where(x => x.IsClass && x.ImplementedInterfaces.Contains(typeof(IHealthConcern)));
        }
    }
}

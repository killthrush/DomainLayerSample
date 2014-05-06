//using Core.Domain;
//using Core.Repository;
using StructureMap.Configuration.DSL;

namespace TestApp
{
    /// <summary>
    /// Class used with StructureMap to set up DI mappings
    /// </summary>
    internal class DependencyRegistry : Registry
    {
        /// <summary>
        /// Constructs an instance of DependencyRegistry
        /// </summary>
        public DependencyRegistry()
        {
            //For<IDomainEntityRepositoryFactory<IDomainEntityRepository<IDomainEntity, IDomainEntity>>>().Use(() => new DomainEntityRepositoryFactory("connectionstring"));
        }
    }
}
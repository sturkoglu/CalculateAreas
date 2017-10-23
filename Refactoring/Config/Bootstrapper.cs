using Refactoring.Repository;
using Refactoring.Services;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;

namespace Refactoring.Config
{
    public class Bootstrapper : IDependencyResolver
    {
        private Container container;

        public Bootstrapper(Container container)
        {
            this.container = container;
        }

        public void Register()
        {
            container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            container.Register<ICommandOperations, CommandOperations>(Lifestyle.Transient);
            container.Register<IShapeRepository, ShapeRepository>(Lifestyle.Transient);
            container.Register<ISelector, ShapeSelector>(Lifestyle.Transient);
            container.Register<ILogger, Logger>(Lifestyle.Transient);

            container.Verify();

        }
    }
}

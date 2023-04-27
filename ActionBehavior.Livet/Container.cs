using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ActionBehavior.Livet
{
    public class Container
    {
        private static Container _instance;
        public static Container Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Container();
                }
                return _instance;
            }
        }

        private CompositionContainer _container;

        public Container()
        {
            var dirCatalog = new DirectoryCatalog(".");
            var exeCatalog = new AssemblyCatalog(Assembly.GetEntryAssembly());

            var aggregateCatalog = new AggregateCatalog(exeCatalog, dirCatalog);
            _container = new CompositionContainer(aggregateCatalog);
        }

        public IActionResolver Resolver { get => _container.GetExportedValue<IActionResolver>(); }
    }
}

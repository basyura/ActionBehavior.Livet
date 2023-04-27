using System.ComponentModel.Composition.Hosting;

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
            _container = new CompositionContainer(new DirectoryCatalog("."));
        }

        public IActionResolver Resolver { get => _container.GetExportedValue<IActionResolver>(); }
    }
}

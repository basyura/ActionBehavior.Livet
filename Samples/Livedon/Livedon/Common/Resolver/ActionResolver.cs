using System.ComponentModel.Composition;
using ActionBehavior.Livet;
using Livet;

namespace Livedon.Common.Resolver
{
    [Export(typeof(IActionResolver))]
    public class ActionResolver : IActionResolver
    {
        public string Resolve(ViewModel vm, string action)
        {
            return $"Livedon.Actions.{action}";
        }
    }
}

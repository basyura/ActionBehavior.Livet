using Livet;

namespace ActionBehavior.Livet
{
    public interface IActionResolver
    {
        string Resolve(ViewModel vm, string action);
    }
}

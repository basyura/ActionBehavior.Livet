# ActionBehavior.Livet

Action Behavior for [Livet](https://github.com/runceel/Livet).  
Provides a function to easily call an action class from View (xaml).

## License

MIT-License


## NuGet

https://www.nuget.org/packages/ActionBehavior.Livet/

## SetUp

* Install [LivetCask.Mvvm](https://www.nuget.org/packages/LivetCask.Mvvm/) and ActionBehavior.Livet by NuGet.
* Add an action resolver in your project.

```cs
using System.ComponentModel.Composition;
using ActionBehavior.Livet;
using Livet;

namespace Hoge
{
    [Export(typeof(IActionResolver))]
    public class ActionResolver : IActionResolver
    {
        public string Resolve(ViewModel vm, string action);
        {
            return $"Hoge.Actions.{action}"
        }
    }
}
```

* Add an ViewModel

```cs
using Livet;

namespace Hoge
{
    public class MainWIndowViewModel : ViewModel
    {
    }
}
```

* Add an action class.

```cs
using System;
using System.Threading.Tasks;
using Livet;

namespace Hoge
{
    public class Hello : ActionCommand<MainWindowViewModel>
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            System.Windows.MessageBox.Show("hello");

            return OK;
        }
    }
}


```

* Call Excute on view (xaml)

```xml
<Window 
        ・・・(略)・・・
        xmlns:ab="clr-namespace:ActionBehavior.Livet;assembly=ActionBehavior.Livet"
        >
    <Window.DataContext>
        <vm:MainWindowViewModel/>
    </Window.DataContext>

```
  
```xml
<Button Content="Hello">
    <i:Interactions.Triggers>
      <i:EventTrigger EventName="Click">
          <ab:Execute Action="Hello" />
      </i:EventTrigger>
    </i:Interactions.Triggers>
</Button>
```


# ActionBehavior.Livet

## License

MIT-License

## Description

Action Behavior for [Livet](https://github.com/runceel/Livet).
Provides a function to easily call an action class from View (xaml).

## NuGet

https://www.nuget.org/packages/ActionBehavior.Livet/

## SetUp

* Install [LivetCask.Mvvm](https://www.nuget.org/packages/LivetCask.Mvvm/) and ActionBehavior.Livet by NuGet.
* Add a action resolver in your project.

```cs:ActionResolver
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

* Add a action class.

```cs:
using System;
using System.Threading.Tasks;
using Livet;

namespace Hoge
{
    public class Hello : ActionCommand<ViewModel>
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

```xml:view (xaml)
<Window 
        ・・・(略)・・・
        xmlns:ab="clr-namespace:ActionBehavior.Livet;assembly=ActionBehavior.Livet"


```
  
```xml:view (xaml)
<Button Content="Hello">
    <i:Interactions.Triggers>
      <i:EventTrigger EventName="Click">
          <ab:Execute Action="Hello" />
      </i:EventTrigger>
    </i:Interactions.Triggers>
</Button>
```


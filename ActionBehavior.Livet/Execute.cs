using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Livet;
using Microsoft.Xaml.Behaviors;

namespace ActionBehavior.Livet
{
    public class Execute : TriggerAction<DependencyObject>
    {
        /// <summary></summary>
        public string Action { get; set; }
        /// <summary></summary>
        public string ActionParameter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="evnt"></param>
        protected override void Invoke(object evnt)
        {
            var vm = GetViewModel();
            if (vm == null)
            {
                MessageBox.Show("No ViewModel");
                return;
            }

            Invoke(vm, evnt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="evnt"></param>
        /// <param name="action"></param>
        /// <param name="param"></param>
        public void Invoke(ViewModel vm, object evnt = null)
        {
            var clsName = BuildClassName(vm, Action);
            var cmd = NewCommand(vm, clsName);
            if (cmd == null)
            {
                MessageBox.Show("Can not createInstance : " + clsName);
                return;
            }

            InvokeAsync(cmd, evnt, ActionParameter).ContinueWith((v) =>
            {
            }).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="evnt"></param>
        /// <returns></returns>
        private async Task<bool> InvokeAsync(IActionCommand cmd, object evnt, string param)
        {
            return await cmd.Execute(AssociatedObject, evnt as EventArgs, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ViewModel GetViewModel()
        {
            var dep = AssociatedObject;
            var ele = AssociatedObject as FrameworkElement;
            if (AssociatedObject is FrameworkElement && ele.DataContext is ViewModel)
            {
                return ele.DataContext as ViewModel;
            }

            while (dep != null)
            {
                dep = LogicalTreeHelper.GetParent(dep);
                ele = dep as FrameworkElement;
                if (ele != null && ele.DataContext is ViewModel)
                {
                    return ele.DataContext as ViewModel;
                }
            }

            var window = Window.GetWindow(AssociatedObject);
            if (window != null)
            {
                return window.DataContext as ViewModel;
            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string BuildClassName(ViewModel vm, string action)
        {
            // 呼び出し対象のクラス名を生成
            //var vmType = vm.GetType();
            //var dir    = vmType.Name.Replace("ViewModel", "");
            //var name   = vmType.FullName;
            var clazz = "LivetSample.Actions." + action;

            return clazz;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IActionCommand NewCommand(ViewModel vm, string clazz)
        {
            var asm = Assembly.GetAssembly(vm.GetType());
            var type = asm.GetType(clazz);
            if (type == null)
            {
                return null;
            }

            var genTypes = type.BaseType.GetGenericArguments();

            var cmd = Activator.CreateInstance(type) as IActionCommand;
            if (cmd == null)
            {
                var vmType = type.BaseType.GetGenericArguments().FirstOrDefault();
                cmd = Activator.CreateInstance(vmType) as IActionCommand;
                if (cmd == null)
                {
                    return null;
                }
            }

            cmd.Initialize(vm);

            return cmd;
        }
    }
}

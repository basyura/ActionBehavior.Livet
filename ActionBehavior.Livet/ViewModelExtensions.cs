using Livet;

namespace ActionBehavior.Livet
{
    public static class ViewModelExtensions
    {
        /// <summary>
        /// Invoke Command.
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="command"></param>
        /// <param name="parameter"></param>
        public static void ExecuteCommand(this ViewModel vm, string command, object parameter = null)
        {
            var exec = new Execute()
            {
                Action = command,
                ActionParameter = parameter,
            };

            exec.Invoke(vm);
        }
    }
}

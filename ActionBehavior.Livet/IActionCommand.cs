using System;
using System.Threading.Tasks;
using Livet;

namespace ActionBehavior.Livet
{
    public interface IActionCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        void Initialize(ViewModel vm);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evnt"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<bool> Execute(object sender, EventArgs evnt, object parameter);
    }
}

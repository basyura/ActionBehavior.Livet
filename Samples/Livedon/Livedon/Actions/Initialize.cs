using System;
using System.Threading.Tasks;

namespace Livedon.Actions
{
    public class Initialize : ActionBase
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            return OK;
        }
    }
}

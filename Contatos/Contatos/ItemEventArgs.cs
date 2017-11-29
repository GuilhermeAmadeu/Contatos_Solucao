using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos
{
    public class ItemEventArgs : EventArgs
    {
        public object Item { get; set; }
        public ItemEventArgs(object item)
        {
            this.Item = item;
        }
    }
}

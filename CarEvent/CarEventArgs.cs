using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvent
{
    class CarEventArgs:EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string massege)
        {
            msg = massege;
        }
    }
}

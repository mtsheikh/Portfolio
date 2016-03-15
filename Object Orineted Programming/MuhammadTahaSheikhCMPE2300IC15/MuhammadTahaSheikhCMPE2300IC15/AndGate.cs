using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadTahaSheikhCMPE2300IC15
{
    public class AndGate : NandGate
    {
        public override void CoreLatch()
        {
            base.CoreLatch();
            _output = !_output;
        }
        public override string CoreName()
        {
            return "And";
        }
    }
}

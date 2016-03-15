using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadTahaSheikhCMPE2300IC15
{
    public class XorGate : Gate
    {
        public override void CoreLatch()
        {
            _output = _input1 ^ _input2;
        }

        public override string CoreName()
        {
            return "Xor";
        }
    }
}

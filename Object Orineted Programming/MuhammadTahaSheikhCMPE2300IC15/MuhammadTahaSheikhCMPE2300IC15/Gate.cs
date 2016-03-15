using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadTahaSheikhCMPE2300IC15
{
    public abstract class Gate
    {
        protected bool _input1;
        protected bool _input2;
        protected bool _output;

        public bool Input1 { get { return _input1; } }
        public bool Input2 { get { return _input2; } }
        public bool Output { get { return _output; } }

        public void Set(bool input1, bool input2)
        {
            _input1 = input1;
            _input2 = input2;

            Latch();
        }

        public void Latch()
        {
            CoreLatch();
        }

        public abstract void CoreLatch();

        public void Name()
        {
            CoreName();
        }

        public abstract string CoreName();
    }

}



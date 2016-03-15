using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadTahaSheikhCMPE2300IC15
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Gate> Gates = new List<Gate>();
            Gates.Add(new AndGate());
            Gates.Add(new OrGate());
            Gates.Add(new NandGate());
            Gates.Add(new XorGate());
            Gates.Add(new NandGate());
            Gates.Add(new OrGate());
            Gates.Add(new AndGate());
            Gates.Add(new XorGate());
            Gates.Add(new AndGate());
            Gates.Add(new OrGate());

            Console.WriteLine(ToTable(Gates));
            Console.ReadKey(true);
        }

        private static string ToTable(List<Gate> Gates)
        {
            StringBuilder name = new StringBuilder();
            name.Append("A B C D O\n");
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 2; b++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        for (int d = 0; d < 2; d++)
                        {
                            // 1
                            Gates[0].Set(a != 0, a != 0); // conversion from int to bool
                            // 2
                            Gates[1].Set(a != 0, b != 0);
                            // 3
                            Gates[2].Set(b != 0, c != 0);
                            // 4
                            Gates[3].Set(Gates[2].Output, c != 0);
                            // 5
                            Gates[4].Set(Gates[0].Output, Gates[1].Output);
                            // 6
                            Gates[5].Set(Gates[0].Output, Gates[4].Output);
                            // 7
                            Gates[6].Set(Gates[1].Output, Gates[3].Output);
                            // 8
                            Gates[7].Set(Gates[3].Output, d != 0);
                            // 9
                            Gates[8].Set(Gates[5].Output, Gates[6].Output);
                            // 10
                            Gates[9].Set(Gates[8].Output, Gates[7].Output);
                            name.Append(a + " " + b + " " + c + " " + d + " " + Convert.ToInt32(Gates[9].Output) + "\n");
                        }
                    }
                }            
            }
            return name.ToString();
        }
    }
}

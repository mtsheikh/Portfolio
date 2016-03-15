using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCMPE2300Ica8
{
    class Sheeple
    {
        private static Random _gen = new Random();

        public int TotalItemsLeftToSearch { get; private set; }
        public int CurrentItemsLeftToSearch { get; private set; }
        public Color SheepleColor { get; private set; }
        public bool Done
        {
            get
            {
                if (CurrentItemsLeftToSearch == 0)
                    return true;

                return false;
            }
        }

        public void Process()
        {
            CurrentItemsLeftToSearch--;
        }

        public Sheeple()
        {
            TotalItemsLeftToSearch = _gen.Next(2, 6);
            CurrentItemsLeftToSearch = TotalItemsLeftToSearch;
            SheepleColor = RandColor.GetColor();
        }
    }
}

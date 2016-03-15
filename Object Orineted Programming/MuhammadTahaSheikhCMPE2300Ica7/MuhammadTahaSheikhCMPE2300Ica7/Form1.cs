using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MuhammadTahaSheikhCMPE2300Ica7
{
    public partial class Form1 : Form
    {
        Thread ShowBlock;
        Thread SumBlock;
        Thread Removeblock;

        List<Thread> Threads = new List<Thread>();

        List<Block> listOfBlocks = new List<Block>();
        Point origin;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Populate_Click(object sender, EventArgs e)
        {
            int runningSum = 0;
            listOfBlocks.Clear();
            do
            {
                Block block = new Block();

                if (!listOfBlocks.Contains(block))
                {
                    listOfBlocks.Add(block);
                    runningSum += block.Width;
                }
            } while (runningSum < ((Block.Canvas.ScaledWidth * Block.Canvas.ScaledHeight) / 20) * 0.80);
            //ShowBlocks();
            TrackbarChange();
        }

        private void tb_scroll_Scroll(object sender, EventArgs e)
        {
            btn_longer.Text = "Longer than " + tb_scroll.Value.ToString();
            lbl_currentVal.Text = tb_scroll.Value.ToString();
        }


        private void ShowBlocks()
        {
            while (true)
            {
                Block.Canvas.Clear();
                lock (listOfBlocks)
                {
                    origin.X = 0;
                    origin.Y = 0;
                    foreach (Block block in listOfBlocks)
                    {
                        block.ShowBlock(origin);

                        origin.X += block.Width;

                        if (origin.X + block.Width > Block.Canvas.ScaledWidth)
                        {
                            origin.Y += 20;
                            origin.X = 0;
                        }
                    }
                }
                Block.Canvas.Render();
                Thread.Sleep(20);
            }
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            listOfBlocks.Sort();
            //ShowBlocks();
        }

        private void btn_Width_Click(object sender, EventArgs e)
        {
            listOfBlocks.Sort(Block.WidthComparison);
            //ShowBlocks();
        }

        private void btn_WidthDesc_Click(object sender, EventArgs e)
        {
            listOfBlocks.Sort((left, right) => -1 * Block.WidthComparison(left, right));
            //ShowBlocks();
        }

        private void btn_WColor_Click(object sender, EventArgs e)
        {
            listOfBlocks.Sort(Block.WidththanColorComparison);
            //ShowBlocks();
        }

        private void btn_bright_Click(object sender, EventArgs e)
        {
            Text = "I have removed " +
               listOfBlocks.RemoveAll(Block.RemoveBright) + " items!";
            //ShowBlocks();
            TrackbarChange();
        }

        private void TrackbarChange()
        {
            if (listOfBlocks.Count > 0)
            {
                tb_scroll.Minimum = listOfBlocks.Min(obj => obj.Width);
                tb_scroll.Maximum = listOfBlocks.Max(obj => obj.Width);
                lbl_min.Text = "Minimum " + tb_scroll.Minimum;
                lbl_max.Text = "Maximum " + tb_scroll.Maximum;
                tb_scroll.Value = (tb_scroll.Minimum + tb_scroll.Maximum) / 2;
                lbl_currentVal.Text = tb_scroll.Value.ToString();
                btn_longer.Text = "Longer than " + tb_scroll.Value.ToString();
            }
            else
            {
                tb_scroll.SetRange(0, 0);
            }
        }

        private void btn_longer_Click(object sender, EventArgs e)
        {
            Text = "I have removed " + listOfBlocks.RemoveAll(obj => obj == null ? false : obj.Width > tb_scroll.Value) + " items!";
            //ShowBlocks();
            TrackbarChange();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            listOfBlocks.ForEach(obj => obj.HighLight = false);
            listOfBlocks.FindAll(obj => Math.Abs(e.X - obj.Width) <= 10).ForEach(obj => obj.HighLight = true);
            //ShowBlocks();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            ShowBlock = new Thread(new ThreadStart(ShowBlocks));
            ShowBlock.IsBackground = true;
            ShowBlock.Start();
            Threads.Add(ShowBlock);

            SumBlock = new Thread((SumBlocks));
            SumBlock.IsBackground = true;
            SumBlock.Start(30);
            Threads.Add(SumBlock);

            Removeblock = new Thread(BlockRemove);
            Removeblock.IsBackground = true;
            Removeblock.Start();
            Threads.Add(Removeblock);
        }

        delegate void delVoidInt(int width);
        delegate int delIntVoid();
        private void SumBlocks(object sleep)
        {

            while (true)
            {
                int sum = 0;
                foreach (Block block in listOfBlocks)
                {
                    sum += block.Width;
                }
                try
                {
                    Invoke(new delVoidInt(UpdateText), sum);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Thread.Sleep((int)sleep);
            }
        }

        private void UpdateText(int sum)
        {

            Text = sum.ToString() + " is the Total Width of all blocks";

        }
        private void BlockRemove()
        {
            while (true)
            {
                try
                {
                    int track = (int)Invoke(new delIntVoid(trackValue));                    
                    lock (listOfBlocks)
                    {
                        Block rem = listOfBlocks.First(b => b.Width < track);
                        if (rem != null)
                            listOfBlocks.Remove(rem);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(1000);
            }
        }

        public int trackValue()
        {
            return tb_remove.Value;    
        }

    }
}

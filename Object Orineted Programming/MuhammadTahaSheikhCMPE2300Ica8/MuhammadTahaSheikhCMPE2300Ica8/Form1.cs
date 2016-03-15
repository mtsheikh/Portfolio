using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace MuhammadTahaSheikhCMPE2300Ica8
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> sheeple = new Stack<Sheeple>();
        List<Queue<Sheeple>> listofQueues = new List<Queue<Sheeple>>();
        CDrawer canvas = null;
        int totalNum;
        bool canvasExist = false;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer_tick.Start();
        }

        private void btn_simulate_Click(object sender, EventArgs e)
        {
            totalNum = 0;
            if (canvasExist)
            {
                canvas.Close();
                canvasExist = false;
            }
            listofQueues.Clear();
            lb_sheepleWaiting.Items.Clear();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                listofQueues.Add(new Queue<Sheeple>());
            }

            if (!canvasExist)
            {
                canvas = new CDrawer(800, (int)numericUpDown1.Value * 20);
                canvas.Scale = 20;
                canvasExist = true;
            }



            for (int i = 0; i < 200; i++)
            {
                sheeple.Push(new Sheeple());
            }         
        }

        private void timer_tick_Tick(object sender, EventArgs e)
        {
            Point p = new Point();

            // Fill the Queues 
            if (canvas != null)
            {
                if (sheeple.Count > 0)
                {
                    foreach (Queue<Sheeple> queue in listofQueues)
                    {
                        if (queue.Count < 10 && sheeple.Count > 0)
                            queue.Enqueue(sheeple.Pop());
                    }
                    lb_sheepleWaiting.Items.Clear();
                    foreach (Sheeple she in sheeple)
                    {
                        lb_sheepleWaiting.Items.Add(she.TotalItemsLeftToSearch);                        
                    }
                }

                // Queue Processing
                foreach (Queue<Sheeple> sheeple in listofQueues)
                {
                    if (sheeple.Count > 0)
                    {
                        Sheeple sheep = sheeple.Peek();
                        sheep.Process();
                        if (sheep.Done)
                        {
                            sheeple.Dequeue();
                            totalNum += sheep.TotalItemsLeftToSearch;
                        }
                    }
                }
                // Display our Queues
                canvas.Clear();
                foreach (Queue<Sheeple> que in listofQueues)
                {
                    foreach (Sheeple she in que)
                    {
                        canvas.AddRectangle(p.X, p.Y, she.TotalItemsLeftToSearch, 1, she.SheepleColor);

                        p.X += she.TotalItemsLeftToSearch;
                    }
                    p.Y += 1;
                    p.X = 0;
                }
                canvas.Render();

                Text = totalNum.ToString();

            }
        }
    }
}

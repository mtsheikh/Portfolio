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
using MuhammadTahaSheikhDrawers;

namespace MuhammadTahaSheikhCMPE2300IC14
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        List<CShape> cShapes = new List<CShape>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer.Enabled = true;
            Timer.Start();
            CShape.Canvas = new newImage(Properties.Resources.Koala);
            CShape.Canvas.ContinuousUpdate = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CShape.Canvas.Clear();
            foreach (CShape shape in cShapes)
            {
                if (shape is IMoveable)
                {
                    (shape as IMoveable).Move();
                }
                if (shape is IAnimate)
                {
                    (shape as IAnimate).Animate();
                }
                shape.Render();
            }
            CShape.Canvas.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point Pcoord;
            if (CShape.Canvas.GetLastMousePosition(out Pcoord))
                switch (e.KeyCode)
                {
                    case Keys.M:
                        cShapes.Add(new MovingBall(Pcoord));
                        break;
                    case Keys.S:
                        cShapes.Add(new SpinnerBall(Pcoord));
                        break;
                    case Keys.O:
                        cShapes.Add(new PentaBall(Pcoord));
                        break;
                    case Keys.C:
                        cShapes.Clear();
                        CShape.Canvas.Clear();
                        break;
                }
        }


    }

}

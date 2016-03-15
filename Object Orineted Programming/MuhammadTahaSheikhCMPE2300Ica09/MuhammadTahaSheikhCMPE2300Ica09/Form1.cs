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

namespace MuhammadTahaSheikhCMPE2300Ica09
{
    public partial class Form1 : Form
    {
        static Random gen = new Random();
        List<Point> points = new List<Point>();
        LinkedList<Point> llPoints = new LinkedList<Point>();
        CDrawer canvas = new CDrawer();

        public Form1()
        {
            InitializeComponent();
        }
        private void btn_top_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            points.Clear();
            while (points.Count < ((canvas.ScaledHeight / (int)nud_Divisor.Value)
                * (canvas.ScaledWidth / (int)nud_Divisor.Value)))
            {
                Point point = new Point();
                point.X = gen.Next(0, canvas.ScaledWidth / (int)nud_Divisor.Value) * (int)nud_Divisor.Value;
                point.Y = gen.Next(0, canvas.ScaledHeight / (int)nud_Divisor.Value) * (int)nud_Divisor.Value;
                if (!(points.Contains(point)))
                {
                    points.Add(point);
                }
            }
            Render();
            btn_top.Text = "List contains: " + points.Count + " points";
        }
        private void Render()
        {
            canvas.Clear();
            for (int i = 0; i < points.Count - 1; i++)
            {
                canvas.AddLine(points[i].X, points[i].Y, points[i + 1].X,
                    points[i + 1].Y, Color.Fuchsia);
            }
            canvas.Render();
        }
        private void btn_bottom_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            llPoints.Clear();
            foreach (Point point in points)
            {
                MakeLinkedList(point);
            }
            for (LinkedListNode<Point> scan = llPoints.First; scan.Next != null; scan = scan.Next)
            {
                canvas.AddLine(scan.Value.X, scan.Value.Y, scan.Next.Value.X,
                   scan.Next.Value.Y, Color.Yellow);
            }
            canvas.Render();
            btn_bottom.Text = "LinkedList contains: " + llPoints.Count + " points";
        }

        private void MakeLinkedList(Point point)
        {
            LinkedListNode<Point> compare = llPoints.First;
            if (llPoints.Count == 0)
            {
                llPoints.AddFirst(point);
            }
            else
            {
                while (compare.Next != null && (compare.Value.Y * canvas.ScaledWidth + compare.Value.X)
                 < (point.Y * canvas.ScaledWidth + point.X))
                {
                    compare = compare.Next;
                }
                if (compare.Next == null && (compare.Value.Y * canvas.ScaledWidth + compare.Value.X)
                 < (point.Y * canvas.ScaledWidth + point.X))
                {
                    llPoints.AddLast(point);
                }   
                else
                {
                    llPoints.AddBefore(compare, point);
                }
            }
        }
    }
}

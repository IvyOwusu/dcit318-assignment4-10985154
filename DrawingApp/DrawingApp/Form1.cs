using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        private bool isDrawing;
        private Point startPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;




        public Form1()
        {
            InitializeComponent();
            InitializeDrawing();
            InitializeCanvas();
        }

        private void InitializeDrawing()
        {
            // Subscribe to mouse events for drawing
            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;
            panel1.Paint += panel1_Paint;

        }

        private void InitializeCanvas()
        {
            drawingBitmap = new Bitmap(panel1.Width, panel1.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Start drawing
            isDrawing = true;
            startPoint = e.Location;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Continue drawing
                drawingGraphics.DrawLine(Pens.Black, startPoint, e.Location);
                startPoint = e.Location; // Update start point for next segment
                panel1.Invalidate();
              //  using (Graphics g = panel1.CreateGraphics())
               // {
               //     g.DrawLine(Pens.Black, startPoint, e.Location);
               // }
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop drawing
            isDrawing = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

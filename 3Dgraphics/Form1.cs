using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Dgraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float Xrot = 0.0f;

        //value used for frame time, higher values=better picture quality, lower value = higher framerate.
        float frametime = 0.0f;
        float XrotSpeed = 0.5f;
        float yrot = 0.0f;
        float bspeed = 0.0f;
        float shootspeed = 2.0f;
        private PaintEventArgs ee;

        /// <summary>
        /// Draw a triangle on a panel
        /// </summary>
        /// <param name="eGraph">the graphics object used</param>
        /// <param name="ePen">the pen used to draw the triangle</param>
        /// <param name="pX1">x value of the first point</param>
        /// <param name="pY1">y value of the first point</param>
        /// <param name="pX2">x value of the second point</param>
        /// <param name="pY2">y value of the second point</param>
        /// <param name="pX3">x value of the third point</param>
        /// <param name="pY3">y value of the third point</param>
        public void DrawTriangle(Graphics eGraph, Pen ePen, float pX1, float pY1, float pX2, float pY2, float pX3, float pY3)
        {
            eGraph.DrawLine(ePen, pX1, pY1, pX2, pY2);
            eGraph.DrawLine(ePen, pX1, pY1, pX3, pY3);
            eGraph.DrawLine(ePen, pX2, pY2, pX3, pY3);
        }
        public void shoot(Graphics eGraph, float xStart, float yStart, float pSpeed, float pReloadTime)
        {

        }
        /// <summary>
        /// transform two floating point values(x and y) into a point with x and y values
        /// </summary>
        /// <param name="pX">horizontal value of the point</param>
        /// <param name="pY">vertical value of the point</param>
        /// <returns>a point with the x and y values equivalent to the floating point parameters</returns>
        public PointF floatToPoint(float pX, float pY)
        {

            PointF p1 = new PointF();
            p1.X = pX;
            p1.Y = pY;

            return p1;
        }



        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Xrot--;
                ScreenPanel_Paint(1, ee);
            }
            else if (e.KeyCode == Keys.A)
            {
                Xrot++;
                ScreenPanel_Paint(1, ee);
            }
            else if (e.KeyCode == Keys.S)
            {
                yrot++;
                ScreenPanel_Paint(1, ee);
            }
            else if (e.KeyCode == Keys.W)
            {
                yrot--;
                ScreenPanel_Paint(1, ee);
            }
            if (e.KeyCode == Keys.Space)
            {
                bspeed = 1;
            }
            else { bspeed = 0.0f; }
        }




        private void ScreenPanel_Paint(object sender, PaintEventArgs e)
        {
            float centerX = ScreenPanel.Width / 2;
            float centerY = ScreenPanel.Height / 2;
            Pen linepen = new Pen(Color.White);
            Brush Backfiller = new SolidBrush(Color.Blue);
            Brush Sidefiller = new SolidBrush(Color.White);
            Graphics draw = ScreenPanel.CreateGraphics();

            //first point
            float x1 = 0.0f;
            float y1 = 0.4f;
            float z1 = 0.1f;
            //second point
            float x2 = 0.3f;
            float y2 = -0.4f;
            float z2 = 0.1f;
            //third point
            float x3 = -0.3f;
            float y3 = -0.4f;
            float z3 = 0.1f;

            //fourth point
            float x4 = 0.1f;
            float y4 = -0.4f;
            float z4 = 0.98f;


            {



                //rotation and transformation Z              
                float pointz1 = 0.5f * (float)((z1 * Math.Cos(Xrot / 200) + 2 - x1 * Math.Sin(Xrot / 200)));
                float pointz2 = 0.5f * (float)((z2 * Math.Cos(Xrot / 200) + 2 - x2 * Math.Sin(Xrot / 200)));
                float pointz3 = 0.5f * (float)((z3 * Math.Cos(Xrot / 200) + 2 - x3 * Math.Sin(Xrot / 200)));
                float pointz4 = 0.5f * (float)((z4 * Math.Cos(Xrot / 200) + 2 - x4 * Math.Sin(Xrot / 200)));
                //rotation and transformation X                
                float pointx1 = centerX + (160 * (float)(x1 * Math.Cos(Xrot / 200) + z1 * Math.Sin(Xrot / 200)) / pointz1) - Xrot * 2;
                float pointx2 = centerX + (160 * (float)(x2 * Math.Cos(Xrot / 200) + z2 * Math.Sin(Xrot / 200)) / pointz2) - Xrot * 2;
                float pointx3 = centerX + (160 * (float)(x3 * Math.Cos(Xrot / 200) + z3 * Math.Sin(Xrot / 200)) / pointz3) - Xrot * 2;
                float pointx4 = centerX + (160 * (float)(x4 * Math.Cos(Xrot / 200) + z4 * Math.Sin(Xrot / 200)) / pointz4) - Xrot * 2;
                //rotation and transform Y                
                float pointy1 = centerY + -(90 * (float)(y1 * Math.Cos(yrot / 200) + z1 * Math.Sin(yrot / 200)) / pointz1) + yrot * 2;
                float pointy2 = centerY + -(90 * (float)(y2 * Math.Cos(yrot / 200) + z2 * Math.Sin(yrot / 200)) / pointz2) + yrot * 2;
                float pointy3 = centerY + -(90 * (float)(y3 * Math.Cos(yrot / 200) + z3 * Math.Sin(yrot / 200)) / pointz3) + yrot * 2;
                float pointy4 = centerY + -(90 * (float)(y4 * Math.Cos(yrot / 200) + z4 * Math.Sin(yrot / 200)) / pointz4) + yrot * 2;
                //storing floating point values in a Points bank
                PointF[] points1 = new PointF[3];
                points1[0] = floatToPoint(pointx1, pointy1);
                points1[1] = floatToPoint(pointx2, pointy2);
                points1[2] = floatToPoint(pointx3, pointy3);
                PointF[] points2 = new PointF[3];
                points2[0] = floatToPoint(pointx1, pointy1);
                points2[1] = floatToPoint(pointx2, pointy2);
                points2[2] = floatToPoint(pointx4, pointy4);
                PointF[] points3 = new PointF[3];
                points3[0] = floatToPoint(pointx1, pointy1);
                points3[1] = floatToPoint(pointx3, pointy3);
                points3[2] = floatToPoint(pointx4, pointy4);
                //drawing routine
                draw.Clear(Color.Black);
                //"for" loop used so there is enough time to draw all lines(not necessary)
                //for (int frame = 0; frame < frametime; frame++)

                {

                    DrawTriangle(draw, linepen, pointx1, pointy1, pointx4, pointy4, pointx2, pointy2);
                    DrawTriangle(draw, linepen, pointx1, pointy1, pointx4, pointy4, pointx3, pointy3);
                    if (pointz4 > pointz1)
                    {
                        draw.FillPolygon(Backfiller, points1);
                        DrawTriangle(draw, linepen, pointx1, pointy1, pointx2, pointy2, pointx3, pointy3);
                    }

                    if (pointx4 > pointx2 - 2)
                    {
                        draw.FillPolygon(Sidefiller, points2);

                    }
                    if (pointx4 < pointx3 + 2)
                    {
                        draw.FillPolygon(Sidefiller, points3);

                    }



                }



            }
        }
    }
}

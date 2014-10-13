using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace MyGame
{
    class DrawShape
    {
        public void Square(float x, float y, float sx, float sy, float r, float g, float b, float alpha)
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(r, g, b, alpha);
            GL.Vertex2(x, y + sy);
            GL.Vertex2(x, y);
            GL.Vertex2(x + sx, y);
            GL.Vertex2(x + sx, y + sy);

            GL.End();
        }

        void Circle(float cx, float cy, float r, int num_segments)
        {
            double theta = 2 * 3.1415926 / Convert.ToDouble(num_segments);
            double c = Math.Cos(theta);
            double s = Math.Sin(theta);
            double t;

            double x = r;//we start at angle = 0 
            double y = 0;

            GL.Begin(PrimitiveType.LineLoop);
            for (int ii = 0; ii < num_segments; ii++)
            {
                GL.Vertex2(x + cx, y + cy);//output vertex 

                //apply the rotation matrix
                t = x;
                x = c * x - s * y;
                y = s * t + c * y;
            }
            GL.End();
        }
    }
}

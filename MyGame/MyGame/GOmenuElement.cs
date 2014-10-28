using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GOmenuElement : GameObject
    {
        public GOmenuElement(float x, float y, float sx, float sy, float r, float g, float b, float a) : base(x, y, sx, sy, r, g, b, a)
        {
            // no need for this shit
        }

        public override void update(double xper, double yper)
        {
            // no need for updates at the moment
        }

        public override void render()
        {
            DrawShape draw = new DrawShape();
            draw.Square(x, y, sx, sy, r, g, b, a);
        }
    }
}

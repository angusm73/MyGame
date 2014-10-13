using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GObutton : GameObject
    {
        public GObutton(float x, float y, float sx, float sy, float r, float g, float b, float a) : base(x, y, sx, sy, r, g, b, a)
        {

        }

        public override void update()
        {
            // all the update shit for GObutton
        }

        public override void render()
        {
            DrawShape draw = new DrawShape();
            draw.Square(x, y, sx, sy, r, g, b, a);
        }
    }
}

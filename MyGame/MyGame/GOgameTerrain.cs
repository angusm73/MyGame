using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GOgameTerrain : GameObject
    {
        public GOgameTerrain(float x, float y, float sx, float sy, float r, float g, float b, float a) : base(x, y, sx, sy, r, g, b, a)
        {
            // nothing to put here just yet
        }

        public override void update(double x, double y)
        {
            // these are static objects at the moment that dont need to be updated just yet
            // probably will need to add shit here for ground collision/physics
        }

        public override void render()
        {
            DrawShape draw = new DrawShape();
            draw.Ground(x, sx, y, sy, a);
        }
    }
}

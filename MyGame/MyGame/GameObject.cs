using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    abstract class GameObject
    {
        public float x, y, sx, sy, r, g, b, a;

        public GameObject(float x, float y, float sx, float sy, float r, float g, float b, float a)
        {
            this.x = x;
            this.y = y;
            this.sx = sx;
            this.sy = sy;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public abstract void update();

        public abstract void render();
    }
}

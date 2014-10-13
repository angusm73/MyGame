using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace MyGame
{
    class GObutton : GameObject
    {
        public GObutton(float x, float y, float sx, float sy, float r, float g, float b, float a) : base(x, y, sx, sy, r, g, b, a)
        {

        }

        public override void update(double xper, double yper)
        {
            var mouse = OpenTK.Input.Mouse.GetState();
            if (xper >= x && xper <= x + sx && yper >= y && yper <= y + sy)
            {
                WriteLog log1 = new WriteLog("GameObject/Button", this.ToString());
            }
        }

        public override void render()
        {
            DrawShape draw = new DrawShape();
            draw.Square(x, y, sx, sy, r, g, b, a);
        }

        public void buttonFunction(int btnID)
        {
            switch (btnID)
            {
                // Start
                case 0:
                    WriteLog log0 = new WriteLog("GameObject/Button", "1");
                    break;
                // Options
                case 1:
                    WriteLog log1 = new WriteLog("GameObject/Button", "2");
                    break;
                // Exit
                case 2:
                    WriteLog log2 = new WriteLog("GameObject/Button", "3");
                    break;
                default:
                    break;
            }
        }
    }
}

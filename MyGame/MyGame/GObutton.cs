using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace MyGame
{
    public class GObutton : GameObject
    {
        Font font = new Font(FontFamily.GenericMonospace, 18.0f);
        OpenTK.Graphics.TextPrinter tp = new OpenTK.Graphics.TextPrinter(OpenTK.Graphics.TextQuality.High);

        public GObutton(float x, float y, float sx, float sy, float r, float g, float b, float a) : base(x, y, sx, sy, r, g, b, a)
        {
            
        }

        public override void update(double xper, double yper)
        {
            var mouse = OpenTK.Input.Mouse.GetState();
            if (xper >= x && xper <= x + sx && yper >= y && yper <= y + sy)
            {
                // WriteLog log1 = new WriteLog("GameObject/Button", this.ToString());
            }
        }

        public override void render()
        {
            DrawShape draw = new DrawShape();
            draw.Square(x, y, sx, sy, r, g, b, a);
            tp.Begin();
            tp.Print("MyGame", font, Color.White);
            tp.End();
        }

        public void buttonFunction(int btnID)
        {
            switch (btnID)
            {
                // Start
                case 0:
                    MyGameWindow.currentGameState = MyGameWindow.gameState.Game;
                    break;

                // Options
                case 1:
                    MyGameWindow.currentGameState = MyGameWindow.gameState.Options;
                    break;

                // Exit
                case 2:
                    MyGameWindow.exit = true;
                    break;
                
                // Fullscreen toggle
                case 3:
                    if (MyGameWindow.winState == WindowState.Fullscreen)
                        MyGameWindow.winState = WindowState.Normal;
                    else
                        MyGameWindow.winState = WindowState.Fullscreen;
                    break;

                default:
                    break;
            }
        }
    }
}

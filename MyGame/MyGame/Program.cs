using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace MyGame
{
    /// <summary>
    /// Demonstrates the GameWindow class.
    /// </summary>
    // [Example("GameWindow Simple", ExampleCategory.OpenTK, "GameWindow", 1, Documentation = "GameWindowSimple")]
    // Not sure where the Example class comes from.
    public class MyGameWindow : GameWindow
    {
        private List<GObutton> menuButtons;

        public MyGameWindow() : base(800, 600, new OpenTK.Graphics.GraphicsMode(32, 0, 0, 16))
        {
            KeyDown += Keyboard_KeyDown;
            menuButtons = new List<GObutton>();
        }

        #region Keyboard_KeyDown

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        /// <param name="sender">The KeyboardDevice which generated this event.</param>
        /// <param name="e">The key that was pressed.</param>
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case (Key.Escape):
                    this.Exit();
                    break;
                
                case (Key.F11):
                    if (this.WindowState == WindowState.Fullscreen)
                        this.WindowState = WindowState.Normal;
                    else
                        this.WindowState = WindowState.Fullscreen;
                    break;
                
                default:
                    WriteLog test = new WriteLog("Main/KeyDown", "I am not sure what I am supposed to do when you press " + e.Key);
                    break;
            }
        }

        #endregion

        #region OnLoad

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not sure why this is used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Title = "My OpenTK Game";

            GL.ClearColor(Color.CornflowerBlue);
            GL.Disable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            menuButtons.Add(new GObutton(-1.0f, -1.0f, 0.6f, 2.0f, 0.0f, 0.0f, 0.0f, 0.4f));
            menuButtons.Add(new GObutton(-1.0f, 0.8f, 0.6f, 0.2f, 0.0f, 0.0f, 0.0f, 0.5f));
            menuButtons.Add(new GObutton(-0.95f, -0.55f, 0.5f, 0.15f, 0.0f, 0.6f, 0.0f, 0.5f));
            menuButtons.Add(new GObutton(-0.95f, -0.75f, 0.5f, 0.15f, 0.0f, 0.0f, 0.6f, 0.5f));
            menuButtons.Add(new GObutton(-0.95f, -0.95f, 0.5f, 0.15f, 0.6f, 0.0f, 0.0f, 0.5f));
        }

        #endregion

        #region OnResize

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        #endregion

        #region OnUpdateFrame

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetState();
            // Console.WriteLine(Mouse.X + ", " + Mouse.Y + " : " + this.Width + ", " + this.Height);
            // Check the position of the mouse
            double xper = (((Mouse.X - this.Width/2)*200)/this.Width)*0.01;
            double yper = (((Mouse.Y - this.Height / 2) * 200) / this.Height) * -0.01;
            if (xper >= -0.95f && xper <= -0.45f && yper >= -0.55 && yper <= -0.4)
            {
                if (mouse[MouseButton.Left])
                {
                    WriteLog log = new WriteLog("Main/Update", "I see that you have clicked Button 1");
                }
                WriteLog log1 = new WriteLog("Main/Update", "I see that you are hovering over Button 1");
            }
            else if (xper >= -0.95f && xper <= -0.45f && yper >= -0.75 && yper <= -0.6)
            {
                if (mouse[MouseButton.Left])
                {
                    WriteLog log = new WriteLog("Main/Update", "I see that you have clicked Button 2");
                }
                WriteLog log2 = new WriteLog("Main/Update", "I see that you are hovering over Button 2");
            }
            else if (xper >= -0.95f && xper <= -0.45f && yper >= -0.95 && yper <= -0.8)
            {
                if (mouse[MouseButton.Left])
                {
                    WriteLog log = new WriteLog("Main/Update", "I see that you have clicked Button 3, I am now exiting.");
                    this.Exit();
                }
                WriteLog log3 = new WriteLog("Main/Update", "I see that you are hovering over Button 3");
            }
        }

        #endregion

        #region OnRenderFrame

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (GObutton button in menuButtons)
            {
                button.render();
            }

            // DrawShape draw = new DrawShape();

            // Shape 1 (Menu text background)
            // draw.Square(-1.0f, -1.0f, 0.6f, 2.0f, 0.0f, 0.0f, 0.0f, 0.4f);

            // Game Logo
            // draw.Square(-1.0f, 0.8f, 0.6f, 0.2f, 0.0f, 0.0f, 0.0f, 0.5f);

            // Menu Item 1
            // draw.Square(-0.95f, -0.55f, 0.5f, 0.15f, 0.0f, 0.6f, 0.0f, 0.5f);

            // Menu Item 2
            // draw.Square(-0.95f, -0.75f, 0.5f, 0.15f, 0.0f, 0.0f, 0.6f, 0.5f);
            
            // Menu Item 3
            // draw.Square(-0.95f, -0.95f, 0.5f, 0.15f, 0.6f, 0.0f, 0.0f, 0.5f);
            
            // Testing shit
            // draw.Circle(0.0f, 0.0f, 0.7f, 1000);

            this.SwapBuffers();
        }

        #endregion

        #region public static void Main()

        /// <summary>
        /// Entry point of this example.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (MyGameWindow example = new MyGameWindow())
            {
                // Get the title and category  of this example using reflection.
                // Utilities.SetWindowTitle(example);
                example.Run(60.0, 60.0);
            }
        }

        #endregion
    }
}

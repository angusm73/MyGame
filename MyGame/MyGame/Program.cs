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
        private List<GObutton> menuItems;

        public MyGameWindow() : base(800, 600, new OpenTK.Graphics.GraphicsMode(32, 0, 0, 16))
        {
            KeyDown += Keyboard_KeyDown;
            menuButtons = new List<GObutton>();
            menuItems = new List<GObutton>();
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

            menuItems.Add(new GObutton(-1.0f, -1.0f, 0.6f, 2.0f, 0.0f, 0.0f, 0.0f, 0.4f));
            menuItems.Add(new GObutton(-1.0f, 0.8f, 0.6f, 0.2f, 0.0f, 0.0f, 0.0f, 0.5f));
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
            double xper = (((Mouse.X - this.Width / 2) * 200) / this.Width) * 0.01;
            double yper = (((Mouse.Y - this.Height / 2) * 200) / this.Height) * -0.01;
            menuButtons.ForEach(delegate(GObutton button)
            {
                button.update(xper, yper);
            });
            // Menu items (background, title) do not need to be updated
            // Menu items should be changed to another GameObject
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

            menuButtons.ForEach(delegate(GObutton button)
            {
                button.render();
            });

            menuItems.ForEach(delegate(GObutton item)
            {
                item.render();
            });

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

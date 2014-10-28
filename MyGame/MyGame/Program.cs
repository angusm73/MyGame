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
        private List<GOmenuElement> menuItems;
        private List<GOgameTerrain> gameTerrain;
        public enum gameState {Menu, Options, Game};

        public static bool exit = false;
        public static WindowState winState = WindowState.Normal;
        public static gameState currentGameState = gameState.Menu;

        public static GOplayer player = new GOplayer(0.1f, 0f, 0.1f, 0.1f, 0.6f, 0.1f, 0.5f, 1.0f);
        public Random rand = new Random();

        public MyGameWindow() : base(800, 600, new OpenTK.Graphics.GraphicsMode(32, 0, 0, 16))
        {
            KeyDown += Keyboard_KeyDown;
            menuButtons = new List<GObutton>();
            menuItems = new List<GOmenuElement>();
            gameTerrain = new List<GOgameTerrain>();
        }

        #region Keyboard_KeyDown

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        /// <param name="sender">The KeyboardDevice which generated this event.</param>
        /// <param name="e">The key that was pressed.</param>
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            // TODO: make this better
            switch (currentGameState)
            {
                case (gameState.Menu):
                    switch (e.Key)
                    {
                        case (Key.Escape):
                            exit = true;
                            break;

                        case (Key.F11):
                            if (winState == WindowState.Fullscreen)
                                winState = WindowState.Normal;
                            else
                                winState = WindowState.Fullscreen;
                            break;

                        default:
                            WriteLog test = new WriteLog("Main/KeyDown", "I am not sure what I am supposed to do when you press " + e.Key);
                            break;
                    }
                    break;

                case (gameState.Options):
                    switch (e.Key)
                    {
                        case (Key.Escape):
                            currentGameState = gameState.Menu;
                            break;

                        case (Key.F11):
                            if (winState == WindowState.Fullscreen)
                                winState = WindowState.Normal;
                            else
                                winState = WindowState.Fullscreen;
                            break;

                        default:
                            WriteLog test = new WriteLog("Main/KeyDown", "I am not sure what I am supposed to do when you press " + e.Key);
                            break;
                    }
                    break;

                case (gameState.Game):
                    switch (e.Key)
                    {
                        case (Key.Escape):
                            currentGameState = gameState.Menu;
                            break;

                        case (Key.F11):
                            if (winState == WindowState.Fullscreen)
                                winState = WindowState.Normal;
                            else
                                winState = WindowState.Fullscreen;
                            break;

                        default:
                            WriteLog test = new WriteLog("Main/KeyDown", "I am not sure what I am supposed to do when you press " + e.Key);
                            break;
                    }
                    break;

                default:
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

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            GL.Rotate(180, new Vector3(0, 1, 0));

            GL.ClearColor(Color.CornflowerBlue);
            GL.Disable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            menuItems.Add(new GOmenuElement(-1.0f, -1.0f, 0.6f, 2.0f, 0.0f, 0.0f, 0.0f, 0.4f));
            menuItems.Add(new GOmenuElement(-1.0f, 0.8f, 0.6f, 0.2f, 0.0f, 0.0f, 0.0f, 0.5f));

            menuButtons.Add(new GObutton(-0.95f, -0.55f, 0.5f, 0.15f, 0.0f, 0.6f, 0.0f, 0.5f));
            menuButtons.Add(new GObutton(-0.95f, -0.75f, 0.5f, 0.15f, 0.0f, 0.0f, 0.6f, 0.5f));
            menuButtons.Add(new GObutton(-0.95f, -0.95f, 0.5f, 0.15f, 0.6f, 0.0f, 0.0f, 0.5f));
            menuButtons.Add(new GObutton(0.95f, 0.95f, 0.05f, 0.05f, 0.0f, 0.0f, 0.0f, 0.5f));

            GameTerrain gt = new GameTerrain(ref gameTerrain, 20, 0.1f);
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

        private void updateGameObjects<T>(List<T> gameObjectList, double xper, double yper) where T : GameObject
        {
            foreach (GameObject go in gameObjectList)
            {
                go.update(xper, yper);
            }
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            double xper = (((Mouse.X - this.Width / 2) * 200) / this.Width) * 0.01;
            double yper = (((Mouse.Y - this.Height / 2) * 200) / this.Height) * -0.01;
            
            var mouse = OpenTK.Input.Mouse.GetState();

            switch (currentGameState)
            {
                case (gameState.Menu):
                    int i = 0;
                    menuButtons.ForEach(delegate(GObutton button)
                    {
                        button.update(xper, yper);
                        if (mouse[MouseButton.Left])
                        {
                            if (xper >= button.x && xper <= button.x + button.sx && yper >= button.y && yper <= button.y + button.sy)
                            {
                                button.buttonFunction(i);
                            }
                        }
                        i++;
                    });
                    break;

                case (gameState.Options):
                    break;

                case (gameState.Game):
                    player.update(xper, yper);
                    updateGameObjects(gameTerrain, xper, yper);
                    break;

                default:
                    break;
            }
            // Menu items (background, title) do not need to be updated
            // Menu items should be changed to another GameObject

            // Check if the program should be closed
            // Temp fix, I should change later
            if (exit == true)
            {
                this.Exit();
            }
            if (this.WindowState != winState)
            {
                this.WindowState = winState;
            }
        }

        #endregion

        #region OnRenderFrame

        private void renderGameObjects<T>(List<T> gameObjectList) where T : GameObject
        {
            foreach (GameObject go in gameObjectList)
            {
                go.render();
            }
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            switch (currentGameState)
            {
                case (gameState.Menu):
                    renderGameObjects(menuItems);
                    renderGameObjects(menuButtons);
                    break;

                case (gameState.Options):
                    renderGameObjects(menuItems);
                    break;

                case (gameState.Game):
                    renderGameObjects(gameTerrain);
                    player.render();
                    break;
            }

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

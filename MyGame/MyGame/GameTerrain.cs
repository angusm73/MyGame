using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameTerrain
    {
        private Random rand = new Random();
        public GameTerrain(ref List<GOgameTerrain> gameTerrain, int sections, float maxDiff)
        {
            float maxHeight = 0.3f;
            float oldHeight = 0.0f;
            float newHeight = 0.0f;
            bool flag = false;
            for (int i = 0; i < sections; i++)
            {
                flag = false;
                while (flag == false)
                {
                    newHeight = (float)rand.NextDouble();
                    if (Math.Abs(Math.Abs(newHeight) - Math.Abs(oldHeight)) <= maxDiff && newHeight < maxHeight)
                    {
                        flag = true;
                    }
                }
                gameTerrain.Add(new GOgameTerrain(-1 + (i / 10f), oldHeight, (sections/200f), newHeight, 0.1f, 0.6f, 0.1f, 1.0f));
                oldHeight = newHeight;
            }
        }
    }
}

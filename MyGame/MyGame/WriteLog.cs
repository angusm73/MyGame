using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class WriteLog
    {
        private String from;
        private String message;

        public WriteLog(String from, String message)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("h:mm:ss") + "] [" + from + "] " + message);
        }
    }
}

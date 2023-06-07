using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class MainLoop
    {
        public event EventHandler<ConsoleKeyInfo>? KeyPress;
        public event EventHandler? Update;
        public event EventHandler? Exit;

        public void Begin()
        {
            ConsoleKeyInfo info;
            do
            {
                while(Console.KeyAvailable == false)
                {
                    Thread.Sleep(100);
                    Update?.Invoke(this, new EventArgs());
                }
                info = Console.ReadKey(true);
                KeyPress?.Invoke(this, info);
            } while (info.Key != ConsoleKey.Escape);
            Exit?.Invoke(this, new EventArgs());
        }
    }
}

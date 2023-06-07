using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public sealed class MainLoop
    {
        public event EventHandler<ConsoleKeyInfo>? KeyPress;
        public event EventHandler? Update;
        public event EventHandler? Exit;

        public void Begin(int wait)
        {
            ConsoleKeyInfo info;
            do
            {
                while(Console.KeyAvailable == false)
                {
                    Thread.Sleep(wait);
                    Update?.Invoke(this, new EventArgs());
                }
                info = Console.ReadKey(true);
                KeyPress?.Invoke(this, info);
            } while (info.Key != ConsoleKey.Escape);
            Exit?.Invoke(this, new EventArgs());
        }
    }
}

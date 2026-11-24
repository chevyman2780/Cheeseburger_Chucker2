using System;
using System.Collections.Generic;
using System.Text;

namespace Cheeseburger_Chucker2
{
    internal class FPS_Handler
    {
        private double write_time = 0.0;
        private readonly double write_delay = 1.0;
        
        public void WriteFPS(double dt)
        {
            write_time += dt;

            if (write_time >= write_delay)
            {
                Console.WriteLine("FPS: " + (int)(1.0 / dt));

                write_time = 0.0;
            }
        }
    }
}

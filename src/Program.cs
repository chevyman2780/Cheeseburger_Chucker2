using System;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Program
{
    [STAThread]
    public static void Main()
    {
        using Game1 game = new();
        game.Run();
    }
}
using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Burger : Projectile
{
    public override string Tag => "burger";
    public override int Damage => 5;

    public override void Update(double dt)
    {

    }
}
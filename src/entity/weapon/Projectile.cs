using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// do not use this class for instantiating projectiles, this is a parent class
internal abstract class Projectile : Entity
{
    public abstract int Damage { get; }

    public override void Update(double dt)
    {

    }
}
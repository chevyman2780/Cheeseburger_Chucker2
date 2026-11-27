using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// do not use this class for instantiating projectiles, this is a parent class
internal abstract class Projectile : Entity
{
    public abstract int Damage { get; } // how much damage does the projectile do

    protected Vector2 _velocity; // the movement speed of the projectile will be dictated by the gun it's shot out of. the _velocity will be set by the gun.

    public override void Update(double dt)
    {

    }
}
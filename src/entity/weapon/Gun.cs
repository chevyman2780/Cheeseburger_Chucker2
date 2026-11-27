using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// do not use this class for instantiating projectiles, this is a parent class
internal abstract class Gun : Entity
{
    public abstract int Damage { get; } // how much damage does the gun do
    protected abstract float _muzzleVelocity { get; } // how fast does projectile leave the gun
    protected double _cooldown; // how much longer until i can fire again

    protected Player _player; // player holding the gun
    protected AssetManager _assetManager;
    protected Scene _scene; // needs access to the scene so it can add projectiles to it

    public abstract void Shoot();
}
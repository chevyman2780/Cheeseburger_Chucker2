using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// i couldn't think of a better name, but Character
// will be the class for the player and enemies
internal abstract class Character : Entity
{
    protected abstract float _movementSpeed { get; } // abstract so that it won't compile if you forget to set _movementSpeed
    public abstract int MaxHealth { get; } // abstract so that it won't compile if you forget to set it
    public int Health { get; protected set; }
    public bool IsDead { get; protected set; }
}
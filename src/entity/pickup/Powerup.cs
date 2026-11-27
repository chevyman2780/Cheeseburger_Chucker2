using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal enum StatusEffect
{
    Speedboost,
    Rapidfire,
}

internal abstract class Powerup : Entity
{
    public abstract StatusEffect Effect { get; } // details what effect this power up applies
    public abstract double Duration { get; } // how long should it last
}
using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal abstract class Entity
{
    private static int _nextId = 0; // static so all instances share this

    public int Id { get; } = _nextId++; // sets identifier of current instance then increments for the next instance
    public abstract string Tag { get; } // tag is the name/type of the enemy. e.g. "tank". abstract so that it won't compile if you forget to set it

    public Vector2 Position { get; protected set; }
    protected abstract float _movementSpeed { get; } // abstract so that it won't compile if you forget to set _movementSpeed
    public int Width { get; protected set; }
    public int Height { get; protected set; }

    public abstract int MaxHealth { get; } // abstract so that it won't compile if you forget to set it
    public int Health { get; protected set; }
    public bool IsDead { get; protected set; }

    public abstract void Update(double dt);
    public virtual void Draw(AssetManager assetManager)
    {
        assetManager.DrawTexture(Tag, Position);
    }

    public virtual void SetPosition(Vector2 position)
    {
        Position = position;
    }
}
using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// this is the parent class for all the powerups. do not use this class for instantiating powerups
internal class Powerup
{
    // all these must be protected instead of private since they will be used by child classes
    protected Vector2 _position;

    protected string _id;

    protected Texture2D[] _textures; // array for animations

    protected int _width;
    protected int _height;

    public Powerup()
    {
        
    }
}
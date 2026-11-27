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

    public Burger(AssetManager assetManager, Vector2 position, Vector2 velocity)
    {
        Width = assetManager.GetTextureWidth(Tag);
        Height = assetManager.GetTextureHeight(Tag);

        Position = position;
        _velocity = velocity;
    }

    public override void Update(double dt)
    {
        Position += _velocity * (float)dt;
    }
}
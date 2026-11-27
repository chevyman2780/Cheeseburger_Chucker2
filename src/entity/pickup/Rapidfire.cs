using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Rapidfire : Powerup
{
    public override string Tag => "rapidfire";
    public override StatusEffect Effect => StatusEffect.Rapidfire;
    public override double Duration => 8; // duration in seconds

    public Rapidfire(AssetManager assetManager)
    {
        // Width = assetManager.GetTextureWidth(Tag);
        // Height = assetManager.GetTextureHeight(Tag);
        Width = 75;
        Height = 75;
    }

    public override void Update(double dt)
    {

    }
}
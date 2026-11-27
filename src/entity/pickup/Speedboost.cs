using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Speedboost : Powerup
{
    public override string Tag => "speedboost";
    public override StatusEffect Effect => StatusEffect.Speedboost;
    public override double Duration => 5; // duration in seconds

    public Speedboost(AssetManager assetManager)
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
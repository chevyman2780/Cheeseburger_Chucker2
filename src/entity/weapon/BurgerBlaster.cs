using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class BurgerBlaster : Gun
{
    public override string Tag => "burger-blaster";
    public override int Damage => 10; // how much damage does the gun do
    protected override float _muzzleVelocity => 400;

    public BurgerBlaster(Player player, AssetManager assetManager)
    {
        _player = player;
        Width = assetManager.GetTextureWidth(Tag);
        Height = assetManager.GetTextureHeight(Tag);
    }

    public override void Update(double dt)
    {
        _flippedHorizontally = _player.IsFlippedHorizontally();

        // subtract by strange Vector2 to get the texture in the right position
        Vector2 arbitaryOffset = Vector2.Zero;
        if (!_flippedHorizontally) arbitaryOffset = new Vector2(-20, 55);
        if (_flippedHorizontally) arbitaryOffset = new Vector2(-40, 55);
        Vector2 newPosition = _player.Position + arbitaryOffset;
        Position = newPosition;
    }

    public void Shoot(Vector2 direction)
    {
        
    }
}
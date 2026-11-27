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

    public BurgerBlaster(Player player, AssetManager assetManager, Scene scene)
    {
        _player = player;
        _assetManager = assetManager;
        _scene = scene;

        Width = assetManager.GetTextureWidth(Tag);
        Height = assetManager.GetTextureHeight(Tag);
    
        _cooldown = 0;
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
    
        if (_player.IsFiring())
        {
            Shoot();
        }

        if (_cooldown - dt > 0)
        {
            _cooldown -= dt;
        }
        else
        {
            _cooldown = 0;
        }
    }

    public override void Shoot()
    {
        if (_cooldown > 0) return;

        Vector2 velocity = Vector2.Zero;
        if (!_player.IsFlippedHorizontally()) velocity = new Vector2(1, 0) * _muzzleVelocity;
        if (_player.IsFlippedHorizontally()) velocity = new Vector2(-1, 0) * _muzzleVelocity;

        Burger burger = new Burger(_assetManager, Position, velocity);

        _scene.AddEntity(burger);

        double cooldownDivider = 1;
        if (_player.HasEffect(StatusEffect.Rapidfire)) cooldownDivider = 5;
        _cooldown = 0.5 / cooldownDivider;
    }
}
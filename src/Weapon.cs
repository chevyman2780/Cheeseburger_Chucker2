using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cheeseburger_Chucker2.src;

internal class Weapon
{
    private Vector2 _Position;
    private Texture2D _weaponTexture;
    private int _weaponWidth;
    private int _weaponHeight;

    private List<Projectile> _projectiles;

    public Weapon(AssetManager _assetManager, string name)
    {
        _weaponTexture = _assetManager.GetTexture(name);

        _projectiles = [];
    }

    public void CreateProjectile(AssetManager _assetManager, string name)
    {
        Projectile chosenProjectile = new(_assetManager, name);

        _projectiles.Add(chosenProjectile);
    }

    public void EquippedWeapon(Controller _controller, AssetManager _assetManager, string ProjectileName, Vector2 UserPosition, Vector2 UserDirection, double dt, string UserFacing)
    {
        _Position.X = UserPosition.X;
        _Position.Y = UserPosition.Y;

        _weaponWidth = _weaponTexture.Width;
        _weaponHeight = _weaponTexture.Height;


        if (_controller.ReadInput(Keys.Space))
        {
            Projectile chosenProjectile = new(_assetManager, "burger");

            chosenProjectile._Position.X = _Position.X;
            chosenProjectile._Position.Y = _Position.Y;

            if (UserFacing == "RIGHT")
            {
                chosenProjectile._Direction.X = 1;
            } else if (UserFacing == "LEFT")
            {
                chosenProjectile._Direction.X = -1;
            }

            _projectiles.Add(chosenProjectile);

            Console.WriteLine(_projectiles);
        }

        if (_projectiles.Count > 0)
        {
            foreach (Projectile projectile in _projectiles)
            {
                // projectile.EquippedProjectile(_Position);
                projectile.Shoot(dt);
            }
        }

    }

    public void Draw_Weapon(AssetManager _assetManager)
    {
        _assetManager.batch.Draw(_weaponTexture, _Position, Color.White);
        
        if (_projectiles.Count > 0)
        {
            foreach (Projectile projectile in _projectiles)
            {
                projectile.Draw_Projectile(_assetManager);
            } 
        }
    }
}
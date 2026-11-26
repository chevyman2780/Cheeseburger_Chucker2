using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Cheeseburger_Chucker2.src;

internal class Projectile(AssetManager _assetManager, string name)
{
    public Vector2 _Position;

    public Vector2 _Direction;

    // Temporary speed; Add JSON that contains projectile information.
    private readonly float _ProjectileSpeed = 500f;

    private Texture2D _ProjectileTexture = _assetManager.GetTexture(name);

    public void EquippedProjectile(Vector2 Position)
    {
        _Position = Position;
    }

    public void Shoot(double dt)
    {
        _Position += _Direction * _ProjectileSpeed * (float)dt;
    }

    public void Draw_Projectile(AssetManager _assetManager)
    {
        _assetManager.batch.Draw(_ProjectileTexture, _Position, Color.White);
    }
}
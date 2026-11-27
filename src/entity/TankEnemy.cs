using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class TankEnemy : Enemy
{
    public override string Tag => "tank";
    protected override float _movementSpeed => 50;
    public override int MaxHealth => 200;

    public TankEnemy()
    {
        Health = MaxHealth;
    }
}
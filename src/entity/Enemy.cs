using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal abstract class Enemy : Entity
{
    protected Entity _targetEntity;

    public override void Update(double dt)
    {
        if (_targetEntity == null) return;
        MoveToTarget(_targetEntity.Position, dt);
    }

    public void SetTarget(Entity entity)
    {
        _targetEntity = entity;
    }

    protected void MoveToTarget(Vector2 targetPosition, double dt)
    {
        Vector2 offset = targetPosition - Position;
        if (offset == Vector2.Zero) return;

        Vector2 direction = Vector2.Normalize(offset);
        Position += direction * _movementSpeed * (float)dt;
        // _position.X += directionToTarget.X * _movementSpeed * (float)dt;
        // _position.Y += directionToTarget.Y * _movementSpeed * (float)dt;
    }
}
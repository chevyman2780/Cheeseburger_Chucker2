using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// this is the parent class for all the enemies. do not use this class for instantiating enemies
internal class Enemy
{
    // all these must be protected instead of private since they will be used by child classes
    protected Vector2 _position;
    protected readonly float _movementSpeed = 50f;

    protected string _id;

    protected Texture2D[] _textures;

    protected int _enemyWidth;
    protected int _enemyHeight;

    public Enemy() 
    {
        _id = "default";
    }

    public void Initialize(AssetManager assetManager) 
    {
        _textures = new Texture2D[1];
        _textures[0] = assetManager.GetTexture(_id); // update this in the future to support animations. will throw error if you don't change the id from "default"

        _enemyWidth = _textures[0].Width;
        _enemyHeight = _textures[0].Height;
    }

    public void Update(Vector2 targetPosition, double dt)
    {
        MoveToTarget(targetPosition, dt);
    }

    public void Draw(AssetManager assetManager)
    {
        assetManager.batch.Draw(_textures[0], _position, Color.White); // update this in the future to support animations
    }

    protected void MoveToTarget(Vector2 targetPosition, double dt)
    {
        Vector2 directionToTarget = Vector2.Normalize(targetPosition - _position); // calculate direction

        // if the enemy position is the same as target position, the direction becomes NaN
        if (float.IsNaN(directionToTarget.X) || float.IsNaN(directionToTarget.Y)) return; // prevents errors

        _position.X += directionToTarget.X * _movementSpeed * (float)dt;
        _position.Y += directionToTarget.Y * _movementSpeed * (float)dt;
    }
}
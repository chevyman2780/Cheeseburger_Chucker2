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

    protected Texture2D[] _textures;

    protected int _width;
    protected int _height;

    protected string _id;
    protected int _health;

    public Enemy() 
    {
        _id = "default";
        _health = 0;
    }

    public void Initialize(AssetManager assetManager) 
    {
        _textures = new Texture2D[1];
        _textures[0] = assetManager.GetTexture(_id); // update this in the future to support animations. will throw error if you don't change the id from "default"

        _width = _textures[0].Width;
        _height = _textures[0].Height;
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
        bool directionInvalid = (float.IsNaN(directionToTarget.X) || float.IsNaN(directionToTarget.Y));

        if (directionInvalid) return;

        _position.X += directionToTarget.X * _movementSpeed * (float)dt;
        _position.Y += directionToTarget.Y * _movementSpeed * (float)dt;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }
}
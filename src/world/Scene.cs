using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Scene
{
    // entities includes the player, enemies, projectiles, powerups, anything like that on screen
    private List<Entity> _entities = new List<Entity>();

    public Scene()
    {

    }

    public void Update(double dt)
    {
        foreach (var entity in _entities)
        {
            entity.Update(dt);
        }

        // add logic down here to randomly spawn powerups every 15-30 seconds
    }

    public void Draw(AssetManager assetManager)
    {
        foreach (var entity in _entities)
        {
            entity.Draw(assetManager);
        }
    }

    public void AddEntity(Entity entity)
    {
        _entities.Add(entity);

        if (entity is not Enemy enemy) return; // creates a usable `enemy` variable if the entity being added *is* an enemy
        foreach (var possiblePlayer in _entities)
        {
            if (possiblePlayer is Player player)
            {
                enemy.SetTarget(player);
            }
        }
    }

    // update entities that need window information whenever the window is resized
    public void OnWindowResize(Rectangle window)
    {
        foreach (var possiblePlayer in _entities)
        {
            if (possiblePlayer is Player player)
            {
                player.OnWindowResize(window);
            }
        }
    }

    // public bool CollisionCheck()
    // {
    //     foreach (var entity1 in _entities)
    //     {
    //         foreach (var entity2 in _entities)
    //         {
    //
    //         }
    //     }
    // }
}
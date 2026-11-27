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

    public void UpdateScene(double dt)
    {
        foreach (var entity in _entities)
        {
            entity.Update(dt);
        }

        // add logic down here to randomly spawn powerups every 15-30 seconds
    }

    public void DrawScene(AssetManager assetManager)
    {
        foreach (var entity in _entities)
        {
            entity.Draw(assetManager);
        }
    }

    public void AddEntity(Entity entity)
    {
        // add entity target for enemies

        _entities.Add(entity);
    }

    public void OnWindowResize(Rectangle window)
    {

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
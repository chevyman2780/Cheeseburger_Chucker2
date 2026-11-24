using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cheeseburger_Chucker2
{
    internal class AssetManager : Game
    {
        private Dictionary<string, Texture2D> _textures = [];
        private readonly string _folderPath = Path.Combine(AppContext.BaseDirectory, "assets");

        public void LoadTextures(GraphicsDevice _GD)
        {
            string[] files = Directory.GetFiles(_folderPath);

            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];

                string fileName = Path.GetFileNameWithoutExtension(filePath);

                using (FileStream stream = File.OpenRead(filePath))
                {
                    Texture2D texture = Texture2D.FromStream(_GD, stream);

                    _textures.Add(fileName, texture);
                }
            }
        }

        public void UnloadTextures()
        {
            foreach (Texture2D texture in _textures.Values)
            {
                texture.Dispose();
            }
        }

        public Texture2D GetTexture(string name)
        {
            return _textures[name];
        }
    }
}

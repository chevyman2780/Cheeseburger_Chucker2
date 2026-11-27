using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cheeseburger_Chucker2.src;

internal class AssetManager
{
    private Dictionary<string, Texture2D> _textures;
    string  _textureJsonPath;

    public SpriteBatch batch;

    public AssetManager()
    {
        _textures = [];
    }

    public void LoadTextures(GraphicsDevice GD, string jsonName)
    {
        _textureJsonPath = $"assets/jsons/{jsonName}.json";

        string _textureJsonText = File.ReadAllText(_textureJsonPath);

        using JsonDocument document = JsonDocument.Parse(_textureJsonText);

        batch = new SpriteBatch(GD);

        foreach (JsonProperty entry in document.RootElement.EnumerateObject())
        {
            string textureName = entry.Name;
            string texturePath = entry.Value.ToString();

            using FileStream stream = File.OpenRead(texturePath);

            Texture2D texture = Texture2D.FromStream(GD, stream);

            _textures.Add(textureName, texture);
        }
    }

    public Texture2D GetTexture(string name)
    {
        return _textures[name];
    }

    public int GetTextureWidth(string name)
    {
        return _textures[name].Width;
    }

    public int GetTextureHeight(string name)
    {
        return _textures[name].Height;
    }

    public void DrawTexture(string name, Vector2 position)
    {
        batch.Draw(GetTexture(name), position, Color.White);
    }

    public void DrawTextureWithRectangle(string name, Rectangle rect)
    {
        batch.Draw(GetTexture(name), rect, Color.White);
    }
}
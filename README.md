# Cheeseburger Chucker 2
### prerequisites:
- .NET SDK v8.0 or higher
### to get this running:
- run `dotnet run`
### formatting suggestions:
- classes, class methods, public properties = PascalCase
- class method parameters, local variables = camelCase
- private properties = _ + camelCase
### current project structure:
everything on the screen (besides the background) is an Entity

below Entity, is Character, Powerup, and Projectile

- Characters include the player and enemies
- Powerups include speedboosts and ammo (may rename Powerups to Pickups)
- Projectiles will include burgers, any other jabber themed things

all of these entities get added to the Scene

the Scene is where everything is updated, everything is drawn on screen,
all collision checks are done, all the "world" logic
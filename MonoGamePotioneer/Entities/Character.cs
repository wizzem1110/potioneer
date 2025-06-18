using System.Buffers.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;

namespace MonoGamePotioneer.Entities;

internal class Character : Entity, IMoveable
{
    public Character(Vector2 position, float speed) : base(position)
    {
        this.Speed = speed;
    }

    public float Speed { get; set; }

    public void Move(float time, Direction direction)
    {
        var distance = this.Speed * time;

        switch (direction)
        {
            case Direction.Up: this.Position.Y -= distance; break;
            case Direction.Left: this.Position.X -= distance; break;
            case Direction.Down: this.Position.Y += distance; break;
            case Direction.Right: this.Position.X += distance; break;
        }
    }
}
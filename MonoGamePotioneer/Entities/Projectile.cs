using System.Buffers.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;

namespace MonoGamePotioneer.Entities;

internal class Projectile : Entity, IMoveable
{
    public Projectile(Vector2 position, float speed, Direction direction) : base(position)
    {
        this.Speed = speed;
        this.Direction = direction;
    }

    public float Speed { get; set; }

    public Direction Direction { get; set; }

    public void Move(float time, Direction direction = default)
    {
        var distance = this.Speed * time;
        direction = this.Direction;

        switch (direction)
        {
            case Direction.Up: this.Position.Y -= distance; break;
            case Direction.Left: this.Position.X -= distance; break;
            case Direction.Down: this.Position.Y += distance; break;
            case Direction.Right: this.Position.X -= distance; break;
        }
    }
}
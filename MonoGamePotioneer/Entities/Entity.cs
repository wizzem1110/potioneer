using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePotioneer.Entities
{
    internal class Entity
    {
        public Vector2 Position;

        public float Speed;

        public Texture2D Texture;

        public Rectangle Collision;

        public Entity(Vector2 position, float speed = 0f)
        {
            Position = position;
            Speed = speed;
        }

        public void AddTexture(Texture2D texture)
        {
            Texture = texture;
            Collision = new Rectangle((int)this.Position.X - 10, (int)this.Position.Y - 10, 20, 20); //problem w/ collision, every object has same collision
            //Collision = new Rectangle(
            //    (int)Position.X - texture.Width / 2,
            //    (int)Position.Y - texture.Height / 2,
            //    texture.Width,
            //    texture.Height);
        }
    }
}

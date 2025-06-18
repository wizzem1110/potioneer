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

        public Texture2D Texture;

        public Rectangle Collision;

        public Entity(Vector2 position)
        {
            Position = position;
            Collision = new Rectangle(
                (int)this.Position.X - 50,
                (int)this.Position.Y - 50,
                100,
                100);
        }

        //todo: current logic may cause problems -> can update collision of entity with no collision
        public void AddTexture(Texture2D texture)
        {
            Texture = texture;
            Collision = new Rectangle(
               (int)Position.X - texture.Width / 2,
               (int)Position.Y - texture.Height / 2,
               texture.Width,
               texture.Height);
        }

        public void UpdateCollision()
        {
            var width = this.Collision.Width;
            var height = this.Collision.Height;

            this.Collision = new Rectangle(
               (int)Position.X - width / 2,
               (int)Position.Y - height / 2,
               width,
               height);
        }

        public void UpdatePosition(Vector2 position)
        {
            this.Position = position;
        }
    }
}

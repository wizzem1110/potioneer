using MonoGamePotioneer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameWindowsDesktopApplication1.Entities
{
    internal class EntityController
    {
        public void MoveEntity(Entity entity, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                {
                    MoveUp(entity);
                    break;
                }
                case Direction.Down:
                {
                    MoveUp(entity);
                    break;
                }
                case Direction.Left:
                {
                    MoveUp(entity);
                    break;
                }
                case Direction.Right:
                {
                    MoveUp(entity);
                    break;
                }
            }
        }

        private void MoveUp(Entity entity)
        {

        }
        private void MoveDown(Entity entity)
        {

        }
        private void MoveLeft(Entity entity)
        {

        }
        private void MoveRight(Entity entity, Direction direction)
        {

        }
    }

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

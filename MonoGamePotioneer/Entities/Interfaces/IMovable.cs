using System.Windows.Forms;

namespace MonoGamePotioneer.Entities
{
    internal interface IMoveable
    {
        float Speed { get; set; }
        void Move(float time, Direction direction);
    }
}
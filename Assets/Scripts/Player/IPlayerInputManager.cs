using UnityEngine;

namespace Player
{
    public interface IPlayerInputManager
    {
        void SetInputForLook(Vector2 lookVector);
        void SetInputForMove(Vector2 lookVector);
        void Interacted();
        void Run(bool p0);
    }
}
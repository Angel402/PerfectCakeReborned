using UnityEngine;

namespace Player
{
    public interface IPlayerMediator
    {
        #region Input
        void SetInputForLook(Vector2 lookVector);
        void SetInputForMove(Vector2 lookVector);
        void Interacted();
        void Run(bool p0);
        void ActionKey1();
        void ActionKey2();
        void ActionKey3();
        void ActionKey4();
        void ShowItems();
        #endregion

        #region Animatior
        void ResetTrigger(string animatorParam);
        void SetTrigger(string animatorParam);
        #endregion

    }
}
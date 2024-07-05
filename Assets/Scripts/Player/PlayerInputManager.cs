using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private IPlayerInputManager _playerInputManager;

        public void Configure(IPlayerInputManager playerInputManager)
        {
            _playerInputManager = playerInputManager;
        }
        
        public void OnLook(InputAction.CallbackContext context)
        {
            var lookVector = context.ReadValue<Vector2>();
            _playerInputManager.SetInputForLook(lookVector);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            var lookVector = context.ReadValue<Vector2>();
            _playerInputManager.SetInputForMove(lookVector);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerInputManager.Interacted();
            }
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerInputManager.Run(true);
            }

            if (context.canceled)
            {
                _playerInputManager.Run(false);
            }
        }
    }
}
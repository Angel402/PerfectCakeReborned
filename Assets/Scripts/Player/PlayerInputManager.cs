using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private IPlayerMediator _playerMediator;

        public void Configure(IPlayerMediator playerMediator)
        {
            _playerMediator = playerMediator;
        }
        
        public void OnLook(InputAction.CallbackContext context)
        {
            var lookVector = context.ReadValue<Vector2>();
            _playerMediator.SetInputForLook(lookVector);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            var lookVector = context.ReadValue<Vector2>();
            _playerMediator.SetInputForMove(lookVector);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.Interacted();
            }
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.Run(true);
            }

            if (context.canceled)
            {
                _playerMediator.Run(false);
            }
        }

        public void OnActionKey1(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.ActionKey1();
            }
        }
        public void OnActionKey2(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.ActionKey2();
            }
        }
        public void OnActionKey3(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.ActionKey3();
            }
        }
        public void OnActionKey4(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.ActionKey4();
            }
        }

        public void OnShowItems(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _playerMediator.ShowItems();
            }
        }
    }
}
using System;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour, IPlayerInputManager
    {
        [SerializeField] private PlayerInputManager playerInputManager;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerInteraction playerInteraction;

        private void Awake()
        {
            playerInputManager.Configure(this);
        }

        public void SetInputForLook(Vector2 lookVector)
        {
            playerCamera.SetMouseInput(lookVector);
        }

        public void SetInputForMove(Vector2 lookVector)
        {
            playerMovement.SetMouseInput(lookVector);
        }

        public void Interacted()
        {
            playerInteraction.Interact();
        }

        public void Run(bool isRunning)
        {
            playerMovement.Run(isRunning);
        }
    }
}
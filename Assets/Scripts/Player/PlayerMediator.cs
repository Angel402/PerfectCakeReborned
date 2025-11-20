using System;
using InteractableObjects.Objects;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class PlayerMediator : MonoBehaviour, IPlayerMediator
    {
        [SerializeField] private PlayerInputManager playerInputManager;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerInteraction playerInteraction;
        [SerializeField] private ScenesSystem scenesSystem;
        [SerializeField] private Animator animator;
        private IDialogSystem _dialogSystem;
        private IInventorySystem _inventorySystem;
        [SerializeField] private MoralSystem moralSystem;
        public bool HasBadMoral
        {
            get => moralSystem.HasBadMoral;
            set => moralSystem.HasBadMoral = value;
        }

        private void Start()
        {
            playerInputManager.Configure(this);
            _dialogSystem = ServiceLocator.Instance.GetService<IDialogSystem>();
            _dialogSystem.Configure(this);
            _inventorySystem = ServiceLocator.Instance.GetService<IInventorySystem>();
            _inventorySystem.Configure(this);
            scenesSystem.Configure(this);
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
            _dialogSystem.Interacted();
        }

        public void Run(bool isRunning)
        {
            playerMovement.Run(isRunning);
        }

        public void ActionKey1()
        {
            _dialogSystem.ActionKey(1);
        }
        
        public void ActionKey2()
        {
            _dialogSystem.ActionKey(2);
        }
        
        public void ActionKey3()
        {
            _dialogSystem.ActionKey(3);
        }
        
        public void ActionKey4()
        {
            _dialogSystem.ActionKey(4);
        }
        
        public void ShowItems()
        {
            _inventorySystem.ShowItems();
        }

        public void ResetTrigger(string animatorParam)
        {
            animator.ResetTrigger(animatorParam);
        }

        public void SetTrigger(string animatorParam)
        {
            animator.SetTrigger(animatorParam);
        }

        public void CloseDialog()
        {
            _dialogSystem.CloseDialog();
        }

        public void RePositionByTransform(Transform playerStartingPosition)
        {
            gameObject.transform.position = playerStartingPosition.position;
            playerCamera.SetRotationInY(playerStartingPosition.eulerAngles.y);
        }

        public void ToggleCanMove(bool canMove)
        {
            playerMovement.CanMove = canMove;
        }

        public void ToggleCanMoveCamera(bool canMove)
        {
            playerCamera.CanMove = canMove;
        }

        public void UseGravity(bool toggle)
        {
            playerMovement.UseGravity(toggle);
        }
    }
}
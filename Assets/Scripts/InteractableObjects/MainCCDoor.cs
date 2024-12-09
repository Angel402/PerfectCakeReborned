using DG.Tweening;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class MainCCDoor : MonoBehaviour
    {
        [SerializeField] private float moveTime;
        [SerializeField] private OutHouseDoorTrigger outHouseDoorTrigger, inHouseDoorTrigger;
        [SerializeField] private Transform rightDoor, leftDoor, targetRightDoor, targetLeftDoor;
        [SerializeField] private bool canOpen;

        private Vector3 _closeRightDoorPosition,
            _closeLeftDoorPosition,
            _openRightDoorPosition,
            _openLeftDoorPosition;

        public bool CanOpen
        {
            set
            {
                canOpen = value;
                OnPlayerIn();
            }
        }

        private void Awake()
        {
            outHouseDoorTrigger.Configure(OnPlayerOut, OnPlayerIn);
            inHouseDoorTrigger.Configure(OnPlayerOut, OnPlayerIn);
            _closeRightDoorPosition = rightDoor.position;
            _closeLeftDoorPosition = leftDoor.position;
            _openRightDoorPosition = targetRightDoor.position;
            _openLeftDoorPosition = targetLeftDoor.position;
        }

        private void OnPlayerOut()
        {
            if (canOpen && !inHouseDoorTrigger.isPlayerIn && !outHouseDoorTrigger.isPlayerIn) OpenDoor(false);
        }
        
        private void OnPlayerIn()
        {
            if (canOpen && !(inHouseDoorTrigger.isPlayerIn && outHouseDoorTrigger.isPlayerIn)) OpenDoor(true);
        }

        private void OpenDoor(bool open)
        {
            DOTween.KillAll();
            if (open)
            {
                rightDoor.DOMove(_openRightDoorPosition, moveTime);
                leftDoor.DOMove( _openLeftDoorPosition, moveTime);
            }
            else
            {
                rightDoor.DOMove(_closeRightDoorPosition, moveTime);
                leftDoor.DOMove(_closeLeftDoorPosition, moveTime);
            }
        }
    }
}
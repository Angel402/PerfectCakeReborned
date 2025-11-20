using DG.Tweening;
using InteractableObjects.Objects;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class HouseDoor : InteractableObject
    {
        [SerializeField] private Dialog firstDialog;
        [SerializeField] private float moveTime;
        [SerializeField] private OutHouseDoorTrigger outHouseDoorTrigger;
        [SerializeField] private InHouseDoorTrigger inHouseDoorTrigger;
        private bool _doorOpen;

        private void Awake()
        {
            outHouseDoorTrigger.Configure(OnPlayerOut);
        }

        private void OnPlayerOut()
        {
            if (!inHouseDoorTrigger.isPlayerIn) OpenDoor(false);
        }

        public override void Interact()
        {
            if (_doorOpen) return;
            firstDialog.Open();
        }

        public void OpenDoor(bool open)
        {
            if (open)
            {
                gameObject.layer = 0;
                inHouseDoorTrigger.gameObject.SetActive(true);
                transform.DORotate(new Vector3(-90, -90, 0), moveTime);
            }
            else
            {
                transform.DORotate(new Vector3(-90, 0, 0), moveTime);
            }
            _doorOpen = true;
        }
    }
}
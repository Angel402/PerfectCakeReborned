using System;
using InteractableObjects.Items;
using Player;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.Serialization;

namespace InteractableObjects
{
    public class WarehouseDoor : InteractableObject
    {
        [SerializeField] private Dialog openDoorDialog;
        [SerializeField] private Animator doorAnimator;
        [SerializeField] private Collider interactionCollider;
        [FormerlySerializedAs("storageRoomKeyItem")] [SerializeField] private Item warehouseRoomKeyItem;
        private bool _doorOpen;

        private void Awake()
        {
            if (ServiceLocator.Instance.GetService<IUtilitySaver>().WarehouseDoorOpen)
                OpenDoor();
        }

        public override void Interact()
        {
            if (_doorOpen) return;
            openDoorDialog.Open();
        }

        public void OpenDoor()
        {
            if (!ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(warehouseRoomKeyItem.ItemName))
                return;
            _doorOpen = true;
            doorAnimator.SetBool("open", true);
            ServiceLocator.Instance.GetService<IUtilitySaver>().WarehouseDoorOpen = true;
            interactionCollider.enabled = false;
        }
    }
}
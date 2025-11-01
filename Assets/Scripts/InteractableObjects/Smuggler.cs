using InteractableObjects.Items;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Smuggler : InteractableObject
    {
        [SerializeField] private Dialog firstDialog,
            dialogMissionAccepted,
            dialogMissionCompleted,
            dialogMissionClosed,
            dialogNoRoomInventory;

        [SerializeField] private Item necklace, candy;
        [SerializeField] private Ingredient poison;
        [SerializeField] private Transform poisonPosition;
        private bool _missionAccepted, _missionClosed;

        public override void Interact()
        {

            if (!_missionAccepted)
            {
                firstDialog.Open();
            }
            else
            {
                if (!_missionClosed)
                {
                    if (ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(necklace.ItemName))
                    {
                        dialogMissionCompleted.Open();
                    }
                    else
                    {  
                        dialogMissionAccepted.Open();
                    }
                }
                else
                {
                    dialogMissionClosed.Open();
                }
            }
        }

        public void AcceptMission()
        {
            if (ServiceLocator.Instance.GetService<IInventorySystem>().HasSpace())
            {
                /*ServiceLocator.Instance.GetService<IInventorySystem>().PickItem(candy);*/
                _missionAccepted = true;
            }
            else
            {
                dialogNoRoomInventory.Open();
            }
        }

        public void MissionCompleted()
        {
            if (ServiceLocator.Instance.GetService<IInventorySystem>().HasSpace())
            {
                ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(necklace.ItemName);
                poison.gameObject.SetActive(true);
                poison.transform.position = poisonPosition.position;
                _missionClosed = true;
            }
        }
    }
}
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

        [SerializeField] private Item necklace, bill, candy;
        private bool _missionAccepted, _missionClosed;

        public override void Interact()
        {

            if (!_missionAccepted)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(firstDialog);
            }
            else
            {
                if (!_missionClosed)
                {
                    if (ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(necklace.ItemName))
                    {
                        ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogMissionCompleted);
                    }
                    else
                    {  
                        ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogMissionAccepted);
                    }
                }
                else
                {
                    ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogMissionClosed);
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
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogNoRoomInventory);
            }
        }

        public void MissionCompleted()
        {
            if (ServiceLocator.Instance.GetService<IInventorySystem>().HasSpace())
            {
                ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(necklace.ItemName);
                _missionClosed = true;
            }
        }
    }
}
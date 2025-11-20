using System.Collections.Generic;
using InteractableObjects.Items;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class WomanToysMission : InteractableObject
    {
        [SerializeField] private Dialog firstDialog, dialogNoItem, dialogItemFound, dialogMissionClosed, dialogMissionCompleted;
        [SerializeField] private List<Item> toys;
        [SerializeField] private Item dollar;
        private bool _missionClosed, _missionAccepted;
        private int _givenToys;

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
                    if (ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(toys[0].ItemName))
                    {
                        dialogItemFound.Open();
                    }
                    else
                    {
                        dialogNoItem.Open();
                    }
                }
                else
                {
                    dialogMissionClosed.Open();
                }
            }
        }

        public void GiveToys()
        {
            while (ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(toys[0].ItemName))
            {
                ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(toys[0].ItemName);
                _givenToys++;
            }

            if (_givenToys >= 3)
            {
                dollar.PickItem();
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogMissionCompleted, true);
                _missionClosed = true;
            }
        }

        public void AcceptMission()
        {
            foreach (var toy in toys)
            {
                toy.gameObject.layer = 7;
            }
            _missionAccepted = true;
        }
    }
}
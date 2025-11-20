using InteractableObjects;
using InteractableObjects.Items;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class EggsVendor : InteractableObject
    {
        [SerializeField]
        private Dialog mainDialog, dialogNoSpace, dialogMissionTaken, dialogMissionClosed, eggSoldDialog;
        private bool _missionTaken, _missionClosed, _eggSold;
        [SerializeField] private Item dollar, commodity, key;
        [SerializeField] private Ingredient egg;

        public override void Interact()
        {
            if (_missionClosed)
            {
                dialogMissionClosed.Open();
                return;
            }

            if (_missionTaken)
            {
                dialogMissionTaken.Open();
                return;
            }

            if (_eggSold)
            {
                eggSoldDialog.Open();
            }
            mainDialog.Open();
        }

        public void TakeMission()
        {
            if (!ServiceLocator.Instance.GetService<IInventorySystem>().HasSpace())
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogNoSpace, true);
            }
            else
            {
                _missionTaken = true;
                key.PickItem();
            }
        }

        public void CompleteMission()
        {
            _missionClosed = true;
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(commodity.ItemName);
        }

        public void BuyEgg()
        {
            _eggSold = true;
            egg.gameObject.SetActive(true);
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(dollar.ItemName);
        }
    }
}
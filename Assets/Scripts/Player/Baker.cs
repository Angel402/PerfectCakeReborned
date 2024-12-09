using InteractableObjects;
using InteractableObjects.Items;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class Baker : InteractableObject
    {
        [SerializeField] private Dialog firstDialog, dialogAllCompleted, dialogSugarMade;
        [SerializeField] private Item dollar, mineral;
        [SerializeField] private Ingredient sugar, flour;
        [SerializeField] private BoxCollider sugarBoxCollider;
        private bool _sugarOwned, _flourOwned, _showSugarMade;
        public override void Interact()
        {
            if (_showSugarMade)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogSugarMade);
                return;
            }
            if (_sugarOwned && _flourOwned)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogAllCompleted);
            }
            else
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(firstDialog);
            }
        }

        public void SellFlour()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(dollar.ItemName);
            flour.gameObject.SetActive(true);
            _flourOwned = true;
            firstDialog.options.Remove(firstDialog.options[0]);
        }

        public void MakeSugar()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(mineral);
            /*sugar.gameObject.SetActive(true);*/
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogSugarMade);
            ServiceLocator.Instance.GetService<IUtilitySaver>().MineralDelivered = true;
            _sugarOwned = true;
        }

        public void BuySugar()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(dollar.ItemName);
            sugarBoxCollider.enabled = true;
            _showSugarMade = false;
            _sugarOwned = true;
            firstDialog.options.Remove(firstDialog.options[1]);
        }

        public void GetDroppedToDie()
        {
            sugar.transform.SetParent(null);
            sugarBoxCollider.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
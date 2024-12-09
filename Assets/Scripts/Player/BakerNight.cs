using InteractableObjects;
using InteractableObjects.Items;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class BakerNight : InteractableObject
    {
        [SerializeField] private Dialog firstDialog, sugarMadeDialog, sugarOwnedDialog;
        [SerializeField] private GameObject sugar;
        private bool _sugarMade, _sugarOwned;
        [SerializeField] private Collider sugarBoxCollider;
        [SerializeField] private Item dollar;

        public override void Interact()
        {
            if (!_sugarMade) ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(firstDialog);
            else if (!_sugarOwned) ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(sugarMadeDialog);
            else ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(sugarOwnedDialog);
        }
        
        public void MakeSugar()
        {
            sugar.gameObject.SetActive(true);
            _sugarMade = true;
        }

        public void BuySugar()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(dollar.ItemName);
            sugarBoxCollider.enabled = true;
            _sugarOwned = true;
        }

        public void GetDroppedToDie()
        {
            sugar.transform.SetParent(null);
            sugarBoxCollider.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
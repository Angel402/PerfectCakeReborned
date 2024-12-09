using InteractableObjects.Items;
using Player;
using ServiceLocatorPath;
using UnityEngine;
using Utility;

namespace InteractableObjects
{
    public class OldWoman : InteractableObject
    {
        [SerializeField] private Dialog dialogNoCandy, dialogWithCandy, dialogAfterBeingRobbed;
        [SerializeField] private Item candy, necklace;
        [SerializeField] private Animator animator;
        private bool _wasRobbed;
        public override void Interact()
        {
            if (_wasRobbed)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogAfterBeingRobbed);
                return;
            }

            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(
                ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(candy.ItemName)
                    ? dialogWithCandy
                    : dialogNoCandy);
        }

        public void GiveCandy()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(candy.ItemName);
            animator.SetTrigger("Steal");
            ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer().HasBadMoral = true;
        }
        
        public void Steal()
        {
            /*ServiceLocator.Instance.GetService<IInventorySystem>().PickItem(necklace);*/
        }
    }
}
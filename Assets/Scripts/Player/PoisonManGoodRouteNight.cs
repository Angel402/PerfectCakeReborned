using InteractableObjects;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class PoisonManGoodRouteNight : InteractableObject
    {
        [SerializeField] private Dialog mainDialog, upstairsDialog, soldDialog;
        private Dialog _currentDialog;

        private void Awake()
        {
            _currentDialog = mainDialog;
            if (!ServiceLocator.Instance.GetService<IUtilitySaver>().TalkedWithPoisonMan) gameObject.SetActive(false);
        }

        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(_currentDialog);
        }

        public void GoUpstairs()
        {
            _currentDialog = upstairsDialog;
        }
        public void SellPoison()
        {
            _currentDialog = soldDialog;
        }
    }
}
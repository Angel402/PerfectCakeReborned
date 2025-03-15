using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class FenceDoor : InteractableObject
    {
        [SerializeField] private Dialog mainDialog, unlockDialog;
        private bool _unLocked;
        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(_unLocked ? unlockDialog : mainDialog);
        }

        public void Unlock()
        {
            _unLocked = true;
        }
    }
}
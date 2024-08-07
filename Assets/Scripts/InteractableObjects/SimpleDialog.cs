using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class SimpleDialog : InteractableObject
    {
        [SerializeField] private Dialog dialog;
        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialog);
        }
    }
}
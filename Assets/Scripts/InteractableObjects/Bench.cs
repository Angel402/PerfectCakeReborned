using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Bench : InteractableObject
    {
        [SerializeField] private Dialog benchDialogCantSit;
        private bool _canSit = false;

        public override void Interact()
        {
            if (!_canSit)
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(benchDialogCantSit);
        }
    }
}
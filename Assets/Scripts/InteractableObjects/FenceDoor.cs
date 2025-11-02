using DG.Tweening;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class FenceDoor : InteractableObject
    {
        [SerializeField] private Dialog mainDialog;
        private bool _unlocked;
        public override void Interact()
        {
            if (!_unlocked) mainDialog.Open();
        }

        public void Unlock()
        {
            _unlocked = true;
            transform.DORotate(new Vector3(0, 90, 0), 1.25f).onComplete += () => enabled = false;
        }
    }
}
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Bench : InteractableObject
    {
        [SerializeField] private Dialog benchDialogCantSit, benchDialogSit;
        [SerializeField] private bool canSit = false;

        public override void Interact()
        {
            if (!canSit || ServiceLocator.Instance.GetService<ITimeSystem>().IsNight())
                benchDialogCantSit.Open();
            else
                benchDialogSit.Open();
        }

        public void SitUntilNight()
        {
            ServiceLocator.Instance.GetService<ITimeSystem>().SitUntilNight();
        }
    }
}
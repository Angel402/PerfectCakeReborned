using System;
using InteractableObjects;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class PoisonMan : InteractableObject
    {
        [SerializeField] private Dialog mainDialog, talkedDialog;
        private bool _talked;
        public override void Interact()
        {
            if (_talked)
            {
                talkedDialog.Open();
            }
            else
            {
                mainDialog.Open();
            }
        }

        public void Talked()
        {
            ServiceLocator.Instance.GetService<IUtilitySaver>().TalkedWithPoisonMan = true;
            _talked = true;
        }
    }
}
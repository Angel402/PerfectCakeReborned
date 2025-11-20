using System;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects.Objects
{
    public class SampleInteractiveObject : InteractableObject
    {
        [SerializeField] private Dialog firstDialog;
        public override void Interact()
        {
            firstDialog.Open();
        }
    }
}
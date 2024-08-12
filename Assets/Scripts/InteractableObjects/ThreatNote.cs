﻿using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class ThreatNote : InteractableObject
    {
        [SerializeField] private Dialog threatDialog;

        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(threatDialog);
        }
    }
}
using System;
using InteractableObjects.Objects;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Clock : InteractableObject
    {
        [SerializeField] private Dialog clockDialog;
        private string _clockDialog;

        private void Awake()
        {
            _clockDialog = clockDialog.text;
        }

        public override void Interact()
        {
            clockDialog.text = _clockDialog + ServiceLocator.Instance.GetService<ITimeSystem>().GetTime();
            clockDialog.Open();
        }
    }
}
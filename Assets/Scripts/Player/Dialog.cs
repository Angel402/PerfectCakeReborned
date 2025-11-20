using System;
using System.Collections.Generic;
using InteractableObjects;
using InteractableObjects.Items;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [Serializable]
    public class Dialog
    {
        [TextArea(3, 10)] public string text;
        public UnityEvent eventsWhenOpen, eventsWhenClose;
        public List<Dialog> options;
        public string lineToSelectDialog;
        public bool IsLastDialog => options.Count == 0;
        public Item itemRequested;

        public void Open()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(this);
        }
    }
}
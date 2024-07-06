using System;
using System.Collections.Generic;
using InteractableObjects.Items;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [Serializable]
    public class Dialog
    {
        [TextArea(3, 10)] public string text;
        public UnityEvent eventsWhenOpen;
        public List<Dialog> options;
        public string lineToSelectDialog;
        public bool isLastDialog;
    }
}
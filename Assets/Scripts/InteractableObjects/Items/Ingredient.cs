using System;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects.Items
{
    public class Ingredient : InteractableObject
    {
        [SerializeField] private string itemName;

        public string ItemName => itemName;
        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IMissionSystem>().CompleteMainObjective(this);
            gameObject.SetActive(false);
        }
    }
}